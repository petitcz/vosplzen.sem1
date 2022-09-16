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
    public class CreateModel : GenericPageModel
    {

        [BindProperty]
        public InventoryItem Item { get; set; }

        public CreateModel(AppDbContext context)
        {
            _context = context;
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

            Item.Modified = DateTime.Now;

            _context.InventoryItems.Add(Item);
            _context.SaveChanges();

            return Redirect("/InventoryPages/Index");
        }
    }
}
