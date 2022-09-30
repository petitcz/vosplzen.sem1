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

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public string CreatedString { get { return Created.ToString("dd.MM.yyyy hh:mm"); } }
        public string ModifiedString { get { return Modified.ToString("dd.MM.yyyy hh:mm"); } }


        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string LastChange
        {
            get
            {
                return Created > Modified ? Created.ToString("dd.MM.yyyy H:mm") : Modified.ToString("dd.MM.yyyy H:mm");
            }
        }

    }
}
