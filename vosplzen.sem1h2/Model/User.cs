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

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string PersonalId { get; set; }


        [NotMapped]
        public string DisplayName { get { return $"{Firstname} {Lastname} ({PersonalId})"; } }

    }
}
