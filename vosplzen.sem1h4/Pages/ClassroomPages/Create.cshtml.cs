using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using vosplzen.sem1h2.Generics;
using vosplzen.sem1h4.Data;
using vosplzen.sem1h4.Data.Model;
using vosplzen.sem1h4.Services.IServices;

namespace vosplzen.sem1h4.Pages.ClassroomPages
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : GenericPageModel
    {

        public CreateModel(IMasterService masterservice)
        {
            _masterservice = masterservice;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Classroom Classroom { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _masterservice.Add<Classroom>(Classroom);

            return RedirectToPage("./Index");
        }
    }
}
