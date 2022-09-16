using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vosplzen.sem1h2.Generics;
using vosplzen.sem1h2.Model;

namespace vosplzen.sem1h2.Pages.UserPages
{
    public class DeleteModel : GenericPageModel
    {
        
        [BindProperty]
        public User UserToDelete { get; set; }

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet(int userid)
        {

            Console.WriteLine(userid);


            UserToDelete = _context.Users.Where(x => x.Id == userid).FirstOrDefault();
        }

        public IActionResult OnPost()
        {
            _context.Users.Remove(UserToDelete);
            _context.SaveChangesAsync();

            return Redirect("Index");
        }
    }
}
