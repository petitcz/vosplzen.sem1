using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vosplzen.sem1h4.Data;
using vosplzen.sem1h4.Data.Model;

namespace vosplzen.sem1h2.Generics
{
    public class GenericPageModel : PageModel
    {
        protected ApplicationDbContext _context { get; set; }
    }
}
