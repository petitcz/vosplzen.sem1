using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using vosplzen.sem1h2.Generics;
using vosplzen.sem1h4.Data;
using vosplzen.sem1h4.Data.Model;
using vosplzen.sem1h4.Services.IServices;

namespace vosplzen.sem1h4.Pages.ClassroomPages
{
    [Authorize(Roles = "Admin, User")]
    public class DetailsModel : GenericPageModel
    {

        public DetailsModel(IMasterService masterservice)
        {
            _masterservice = masterservice;
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
