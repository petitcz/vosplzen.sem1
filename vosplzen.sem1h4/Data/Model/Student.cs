using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vosplzen.sem1h4.Data.Model
{
    public class Student:IdentityUser<int>
    {
        public bool IsActive { get; set; } = true;
        public DateTime Modified { get; set; } = DateTime.Now;
        [Required]
        public string Class { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [NotMapped]
        public string DisplayName { 
            get { return FirstName + " " + LastName; } 
        }
    }
}
