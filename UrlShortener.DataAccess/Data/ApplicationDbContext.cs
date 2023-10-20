using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;
using UrlShortener.Utility;

namespace UrlShortener.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        { 

        }
        public DbSet<Url> Urls { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AdminEmail> AdminEmails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminEmail>().HasData(new AdminEmail[]
            {
                new AdminEmail {Id = 1, Email = "kirilkvas07@gmail.com"},
                new AdminEmail {Id = 2, Email = "admin@gmail.com"}
            });
        }
    }
}
