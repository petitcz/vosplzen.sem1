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
    public class IndexModel : GenericPageModel
    {
        IStudentService _studentservice;
        public List<Student> Students { get; set; }
        public IndexModel(IStudentService studentservice)
        {
            _studentservice = studentservice;
        }

        public void OnGet()
        {
            Students = _studentservice.GetAll();
        }
    }
}
