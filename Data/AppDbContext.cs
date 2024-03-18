using Microsoft.EntityFrameworkCore;
using AuthorizationApp.Models;

namespace AuthorizationApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AuthorizationAppDb;Trusted_Connection=True;");
        }
    }
}