using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vosplzen.sem1h2.Generics;
using vosplzen.sem1h2.Model;

namespace vosplzen.sem1h2.Pages.InventoryPages
{
    public class EditModel : GenericPageModel
    {
        [BindProperty]
        public InventoryItem EditItem { get; set; }

        public EditModel(AppDbContext context)
        {

            _context = context;
        }
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {

                return Page();
            }
            _context.InventoryItems.Update(EditItem);
            _context.SaveChanges();

            return Redirect("/InventoryPages/Index");
        }
        public void OnGet(int itemId)
        {

            EditItem = _context.InventoryItems.Where(x => x.Id == itemId).FirstOrDefault();
        }
    }
}
