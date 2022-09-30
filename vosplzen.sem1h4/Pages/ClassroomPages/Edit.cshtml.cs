using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vosplzen.sem1h2.Generics;
using vosplzen.sem1h4.Data;
using vosplzen.sem1h4.Data.Model;
using vosplzen.sem1h4.Services.IServices;

namespace vosplzen.sem1h4.Pages.ClassroomPages
{
    [Authorize(Roles = "Admin")]
    public class EditModel : GenericPageModel
    {

        public EditModel(IMasterService masterservice)
        {
            _masterservice = masterservice;
        }

        [BindProperty]
        public Classroom Classroom { get; set; }

        public IActionResult OnGet(int? id)
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


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _masterservice.Update<Classroom>(Classroom);
                
            return RedirectToPage("./Index");
        }


    }
}
