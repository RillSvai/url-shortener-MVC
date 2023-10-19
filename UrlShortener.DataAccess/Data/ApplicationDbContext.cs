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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Url>().HasData(new Url[]
            {
                new Url { Id = 1, OriginalUrl = "Test1Long", ShortUrl = "Test1Short", TokenShortUrl = "test1", CreatorId = 1},
                new Url { Id = 2, OriginalUrl = "Test2Long", ShortUrl = "Test2Short", TokenShortUrl = "test2", CreatorId = 2}
            });
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User { Id = 1, UserName = "Test1Name", Email = "Test1Email", Password = "Test1Password", Role = SD.Role_Customer},
                new User { Id = 2, UserName = "Test2Name", Email = "Test2Email", Password = "Test2Password", Role = SD.Role_Admin}
            });
        }
    }
}
