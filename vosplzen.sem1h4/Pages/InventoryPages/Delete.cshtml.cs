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

namespace vosplzen.sem1h4.Pages.InventoryPages
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : GenericPageModel
    {

        [BindProperty]
        public InventoryItem ItemToDelete { get; set; }
        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int itemId)
        {

            ItemToDelete = _context.InventoryItems.Where(x => x.Id == itemId).FirstOrDefault();
        }
        public IActionResult OnPost()
        {
            _context.InventoryItems.Remove(ItemToDelete);
            _context.SaveChanges();

            return Redirect("Index");
        }
    }
}
