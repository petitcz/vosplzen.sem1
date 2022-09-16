using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vosplzen.sem1h2.Model;

namespace vosplzen.sem1h2.Pages.UserPages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public User DelUser { get; set; }
        private AppDbContext _context { get; set; }
        public DeleteModel(AppDbContext context)
        {

            _context = context;
        }

        public IActionResult OnPost() {

            DelUser = _context.Users.Where(x => x.Id == DelUser.Id).FirstOrDefault();

            _context.Users.Remove(DelUser);
            _context.SaveChanges();

            return Redirect("/UserPages/Index");
        }
        public void OnGet(int userid)
        {

            DelUser = _context.Users.Where(x => x.Id == userid).FirstOrDefault();
        }
    }
}
