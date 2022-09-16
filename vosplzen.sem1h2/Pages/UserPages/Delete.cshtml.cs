using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace vosplzen.sem1h2.Pages.UserPages
{
    public class DeleteModel : PageModel
    {
        public void OnGet(int userid)
        {

            Console.WriteLine(userid);
            

        }
    }
}
