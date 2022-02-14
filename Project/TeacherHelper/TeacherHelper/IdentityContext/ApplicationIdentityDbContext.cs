using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherHelper.Models.Identity;

namespace TeacherHelper.IdentityContext
{
    public class ApplicationIdentityDbContext : IdentityDbContext<User, Role, string>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData
                (
                    new Role { Name = "Teacher",NormalizedName = "Teacher"},
                    new Role { Name = "Student", NormalizedName = "Student"},
                    new Role { Name = "Guest", NormalizedName = "Guest" },
                    new Role { Name = "Admin", NormalizedName = "Admin"}
                );
            base.OnModelCreating(builder);
        }
    }
}
