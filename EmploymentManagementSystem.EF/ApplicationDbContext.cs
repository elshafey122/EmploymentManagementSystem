using EmployeeManagementSystem.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taski = EmployeeManagementSystem.Core.Models.Taski;

namespace EmployeeManagementSystem.EF
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Core.Models.Taski> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Taski>().HasOne(x => x.Employee).WithMany(x => x.Tasks).
                HasForeignKey(i => new { i.AssignTo, i.AssignFrom }).
                HasPrincipalKey(x => new { x.Id, x.ManagerId });
            seedroles(modelBuilder);
        }
        private static void seedroles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole { Name = "user", ConcurrencyStamp = "2", NormalizedName="User" }
            );
        }
    }
}
