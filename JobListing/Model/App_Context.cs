using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Model
{
    public class App_Context:DbContext
    {
        public App_Context(DbContextOptions<App_Context> options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(f => f.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelbuilder);
        }
        public DbSet<User> USER { get; set; }
        public DbSet<Company> COMPANY { get; set; }
        public DbSet<Job_Listing> JOB_LISTING { get; set; }
        public DbSet<Job_Applicant> JOB_APPLICANT { get; set; }
        public DbSet<User_Type> USER_TYPE { get; set; }
    }
}
