using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vosplzen.sem1.Core;
using vosplzen.sem1.Model;

namespace vosplzen.sem1.Pages
{

    public class LanguageModel : PageModel
    {


        [BindProperty]
        public PageContent PageContent { get; set; }



        public IActionResult OnGet()
        {

            PageContent = Localizer.GetGdprPageContent("de");



            return Page();
        }

        public IActionResult OnPost()
        {
            PageContent.Language = (PageContent.Language.Equals("de") ? "en" : "de");
            PageContent = Localizer.GetGdprPageContent(PageContent.Language);

            ModelState.Clear();

            return Page();
        }

    }
}
