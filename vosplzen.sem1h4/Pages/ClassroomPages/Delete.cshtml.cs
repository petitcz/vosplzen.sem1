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
    [Authorize(Roles = "Admin")]
    public class DeleteModel : GenericPageModel
    {
        public DeleteModel(IMasterService masterservice)
        {
            _masterservice = masterservice;
        }

        [BindProperty]
        public Classroom Classroom { get; set; }

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Classroom = _masterservice.GetById<Classroom>((int)id);

            if (Classroom == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            if (Classroom != null)
            {
                _masterservice.Delete<Classroom>((int)id);
            }

            return RedirectToPage("./Index");
        }
    }
}
