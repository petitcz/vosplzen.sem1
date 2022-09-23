using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vosplzen.sem1h3.Data.Model
{
    public class InventoryItem : Generics.Generic
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string SerNum { get; set; }

        [NotMapped]
        public string DisplayName { get { return $"{Title} {SerNum}"; } }
    }
}
