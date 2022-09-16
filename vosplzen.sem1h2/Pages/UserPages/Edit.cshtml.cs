using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vosplzen.sem1h2.Model;

namespace vosplzen.sem1h2.Pages.UserPages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public User EditUser { get; set; }
        private AppDbContext _context { get; set; }

        public EditModel(AppDbContext context)
        {

            _context = context;
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {

                return Page();
            }
            _context.Users.Update(EditUser);
            _context.SaveChanges();

            return Redirect("/UserPages/Index");
        }
        public void OnGet(int userid)
        {

            EditUser = _context.Users.Where(x => x.Id == userid).FirstOrDefault();
        }
    }
}
