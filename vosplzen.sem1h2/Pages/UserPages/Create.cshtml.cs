using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vosplzen.sem1h2.Model;

namespace vosplzen.sem1h2.Pages.UserPages
{
    public class CreateModel : PageModel
    {
        private AppDbContext _context { get; set; }

        [BindProperty]
        public User User { get; set; }

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            User.Modified = DateTime.Now;
          
            _context.Users.Add(User);
            _context.SaveChanges();

            return Redirect("/UserPages/Index");
        }


    }
}
