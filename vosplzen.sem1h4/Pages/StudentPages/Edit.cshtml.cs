using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vosplzen.sem1h2.Generics;
using vosplzen.sem1h4.Data;
using vosplzen.sem1h4.Data.DTO;
using vosplzen.sem1h4.Data.Model;
using vosplzen.sem1h4.Services.IServices;

namespace vosplzen.sem1h4.Pages.StudentPages
{
    [Authorize(Roles = "Admin")]
    public class EditModel : GenericPageModel
    {
        [BindProperty]
        public StudentDTO EditStudent { get; set; }
        IStudentService _studentservice;

        public EditModel(IStudentService studentservice)
        {
            _studentservice = studentservice;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _studentservice.Update(EditStudent);

            return Redirect("/StudentPages/Index");
        }
        public void OnGet(int itemId)
        {

            EditStudent = _studentservice.GetDtoById(itemId); 
        }
    }
}
