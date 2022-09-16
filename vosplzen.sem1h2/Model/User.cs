using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vosplzen.sem1h2.Model
{
    public class User : Generics.Generic
    { 

        [MaxLength(30, ErrorMessage =  "Pole nesmí mít přes 30 znaků")]
        [Required (ErrorMessage = "Křestní je povinné pole!")]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string PersonalId { get; set; }
        
        [NotMapped]
        public string DisplayName { get { return $"{Firstname} {Lastname}"; } }

    }
}
