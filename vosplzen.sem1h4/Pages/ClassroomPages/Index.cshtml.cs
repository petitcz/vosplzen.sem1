using System;
using System.Collections.Generic;
using System.Data;
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
    public class IndexModel : GenericPageModel
    {

        public IndexModel(IMasterService masterservice)
        {
            _masterservice = masterservice;
        }

        public IList<Classroom> Classrooms { get;set; }

        public void OnGetAsync()
        {
            Classrooms = _masterservice.GetAll<Classroom>();
        }
    }
}
