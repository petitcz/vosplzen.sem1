using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vosplzen.sem1h4.Data.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string UserName { get; set; }
    }
}
