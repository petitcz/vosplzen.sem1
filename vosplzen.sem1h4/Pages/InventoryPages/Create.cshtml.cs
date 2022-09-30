using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vosplzen.sem1h4.Data.Model.Generics;
using vosplzen.sem1h4.Data.Model;
using vosplzen.sem1h4.Data;
using vosplzen.sem1h2.Generics;
using Microsoft.AspNetCore.Authorization;
using vosplzen.sem1h4.Services.IServices;

namespace vosplzen.sem1h4.Pages.InventoryPages
{

    [Authorize(Roles = "Admin")]
    public class CreateModel : GenericPageModel
    {

        [BindProperty]
        public InventoryItem Item { get; set; }

        public CreateModel(IMasterService masterservice)
        {
            _masterservice = masterservice;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _masterservice.Add<InventoryItem>(Item);


            return Redirect("/InventoryPages/Index");
        }
    }
}
