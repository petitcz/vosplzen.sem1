using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vosplzen.sem1h4.Data.Model
{
    public class Classroom:Generics.Generic
    {
        [Required]
        [MaxLength(10)]
        public string Title { get; set; }

    }
    
}
