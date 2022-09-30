using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace vosplzen.sem1h4.Data.Model.Generics
{
    public class Generic
    {        
        [Key]
        public int Id { get; set; }

        public DateTime Modified { get; set; } = DateTime.Now;
    }
}
