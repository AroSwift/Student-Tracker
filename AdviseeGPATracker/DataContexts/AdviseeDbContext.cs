using AdviseeGPATracker.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviseeGPATracker.DataContexts
{
    /*
    * Define LINQ connection and map entities
    */
    public class AdviseeDbContext : DbContext
    {
        /*
        * Constructor to define LINQ connection
        */
        public AdviseeDbContext(DbContextOptions options) : base(options)
        {
        }

        // Define advisees and courses as tables to which to map
        public DbSet<Advisee> Advisees { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
