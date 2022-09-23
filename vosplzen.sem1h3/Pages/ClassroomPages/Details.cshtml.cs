using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using vosplzen.sem1h3.Data;
using vosplzen.sem1h3.Data.Model;

namespace vosplzen.sem1h3.Pages.ClassroomPages
{
    [Authorize(Roles = "Admin, User")]
    public class DetailsModel : PageModel
    {
        private readonly vosplzen.sem1h3.Data.ApplicationDbContext _context;

        public DetailsModel(vosplzen.sem1h3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Classroom Classroom { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Classroom = await _context.Classrooms.FirstOrDefaultAsync(m => m.Id == id);

            if (Classroom == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
