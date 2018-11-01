using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RtfWebApp.Data
{
    using Models;
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Skil> Skills { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<SkillDependency> SkillDependencies { get; set; }
        public DbSet<Achivment> Achivments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<ProfileSkils> ProfileSkils {get;set;}
        public DbSet<EmployeeAchivments> UserAchivments { get; set; }
        public DbSet<EmployeeSolutions>  EmployeeSolutions { get; set; }
    }
}
