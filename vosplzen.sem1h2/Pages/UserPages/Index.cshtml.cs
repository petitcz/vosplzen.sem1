using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vosplzen.sem1h2.Model;

namespace vosplzen.sem1h2.Pages.UserPages
{

    public class IndexModel : PageModel
    {

        public List<User> Users { get; set; }

        private AppDbContext _context { get; set; }

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

            Users = _context.Users.ToList();


        }
    }
}
