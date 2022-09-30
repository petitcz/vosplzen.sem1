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

    [Authorize(Roles = "Admin, User")]
    public class IndexModel : GenericPageModel
    {
        public List<InventoryItem> Items { get; set; }
        public IndexModel(IMasterService masterservice)
        {
            _masterservice = masterservice;
        }

        public void OnGet()
        {
            Items = _masterservice.GetAll<InventoryItem>();
        }
    }
}
