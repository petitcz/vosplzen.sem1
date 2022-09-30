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

namespace vosplzen.sem1h4.Pages.InventoryPages
{
    [Authorize(Roles = "Admin")]
    public class EditModel : GenericPageModel
    {
        [BindProperty]
        public InventoryItem EditItem { get; set; }

        public EditModel(IMasterService masterservice)
        {
            _masterservice = masterservice;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _masterservice.Update<InventoryItem>(EditItem);

            return Redirect("/InventoryPages/Index");
        }
        public void OnGet(int itemId)
        {

            EditItem = _context.InventoryItems.Where(x => x.Id == itemId).FirstOrDefault();
        }
    }
}
