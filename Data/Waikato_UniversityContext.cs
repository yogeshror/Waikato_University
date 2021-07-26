using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Waikato_University.Models;

namespace Waikato_University.Data
{
    public class Waikato_UniversityContext : DbContext
    {
        public Waikato_UniversityContext (DbContextOptions<Waikato_UniversityContext> options)
            : base(options)
        {
        }

        public DbSet<Waikato_University.Models.Allocation> Allocation { get; set; }

        public DbSet<Waikato_University.Models.Department> Department { get; set; }

        public DbSet<Waikato_University.Models.Lacturer> Lacturer { get; set; }

        public DbSet<Waikato_University.Models.Module> Module { get; set; }
    }
}
