using Demo.Models;
using Fluent.Infrastructure.FluentModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Demo.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {


        }
        public DbSet<Category> Categories{ get; set;}
        public DbSet<ApplicationUser> ApplicationUsers { get; set;} 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         base.OnModelCreating(modelBuilder);   
        }
    }
}
