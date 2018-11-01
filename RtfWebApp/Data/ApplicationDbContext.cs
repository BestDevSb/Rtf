using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RtfWebApp.Data
{
    using Models;
    public class ApplicationDbContext:  IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SkillDependency>().HasOne(x => x.SkilA).WithMany(x => x.Dependencies).HasForeignKey(x => x.SkilAId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SkillDependency>().HasOne(x => x.SkilB).WithMany(x => x.Dependendenties).HasForeignKey(x => x.SkilBId).OnDelete(DeleteBehavior.Restrict);
            builder.Query<EmployeeRating>().ToView("V_EMPLOYEESRATES");
            base.OnModelCreating(builder);
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Skil> Skills { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<SkillDependency> SkillDependencies { get; set; }
        public DbSet<Achivment> Achivments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<AuthorRating> AuthorRatings { get; set; }
        public DbSet<ProfileSkills> ProfileSkils {get;set;}
        public DbSet<EmployeeAchivments> UserAchivments { get; set; }
        public DbSet<EmployeeSolutions>  EmployeeSolutions { get; set; }
        public DbQuery<EmployeeRating> EmployeeRating { get; set; }
    }
}
