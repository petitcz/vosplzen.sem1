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
    public class DeleteModel : GenericPageModel
    {

        [BindProperty]
        public InventoryItem ItemToDelete { get; set; }
        public DeleteModel(IMasterService masterservice)
        {
            _masterservice = masterservice;
        }
        public void OnGet(int itemId)
        {

            ItemToDelete = _masterservice.GetById<InventoryItem>(itemId);
        }
        public IActionResult OnPost()
        {
            _masterservice.Delete<InventoryItem>(ItemToDelete.Id);

            return Redirect("Index");
        }
    }
}
