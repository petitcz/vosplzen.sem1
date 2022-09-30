using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vosplzen.sem1h2.Generics;
using vosplzen.sem1h4.Data;
using vosplzen.sem1h4.Data.Model;
using vosplzen.sem1h4.Services.IServices;

namespace vosplzen.sem1h4.Pages.StudentPages
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : GenericPageModel
    {

        [BindProperty]
        public Student StudentToDelete { get; set; }
        IStudentService _studentservice;
        public DeleteModel(IStudentService studentservice)
        {
            _studentservice = studentservice;
        }
        public void OnGet(int itemId)
        {

            StudentToDelete = _studentservice.GetById(itemId);
        }
        public IActionResult OnPost()
        {
            _studentservice.Delete(StudentToDelete.Id);

            return Redirect("Index");
        }
    }
}
