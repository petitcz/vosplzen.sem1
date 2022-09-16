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
    public class IndexModel : GenericPageModel
    {
        public List<InventoryItem> Items { get; set; }
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

            Items = _context.InventoryItems.ToList();
        }
    }
}
