using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using vosplzen.sem1h3.Data.Model;

namespace vosplzen.sem1h3.Data
{
    public class ApplicationDbContext : IdentityDbContext<Student>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
