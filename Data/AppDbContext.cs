using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using AuthorizationApp.Models;

namespace AuthorizationApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\AuthorizationAppDb.sqlite"));
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}