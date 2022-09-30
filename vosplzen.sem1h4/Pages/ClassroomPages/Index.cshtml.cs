using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using vosplzen.sem1h4.Data;
using vosplzen.sem1h4.Data.Model;

namespace vosplzen.sem1h4.Pages.ClassroomPages
{
    [Authorize(Roles = "Admin, User")]
    public class IndexModel : PageModel
    {
        private readonly vosplzen.sem1h4.Data.ApplicationDbContext _context;

        public IndexModel(vosplzen.sem1h4.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Classroom> Classroom { get;set; }

        public async Task OnGetAsync()
        {
            Classroom = await _context.Classrooms.ToListAsync();
        }
    }
}
