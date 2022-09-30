using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vosplzen.sem1h4.Data.Model.Generics
{
    public class Generic
    {
        [Key]
        public int Id { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

  
        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }


        [NotMapped]
        public string CreatedString { get { return Created.ToString("dd.MM.yyyy hh:mm"); } }

        [NotMapped]
        public string ModifiedString { get { return Modified.ToString("dd.MM.yyyy hh:mm"); } }

        [NotMapped]
        public string LastChange
        {
            get
            {
                return Created > Modified ? Created.ToString("dd.MM.yyyy H:mm") : Modified.ToString("dd.MM.yyyy H:mm");
            }
        }

    }
}
