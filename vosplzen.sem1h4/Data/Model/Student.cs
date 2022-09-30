using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vosplzen.sem1h4.Data.Model
{
    public class Student:IdentityUser<int>
    {
        [Required]
        public string Class { get; set; }

    }
}
