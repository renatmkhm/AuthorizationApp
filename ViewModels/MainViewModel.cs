using System.Threading.Tasks;
using AuthorizationApp.Models;
using AuthorizationApp.Utilities;
using AuthorizationApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationApp.ViewModels
{
    public class MainViewModel
    {
        private const int MinPasswordLength = 6;
        
        public async Task<string> Register(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < MinPasswordLength)
            {
                return $"Password must be at least {MinPasswordLength} characters long.";
            }
            
            PasswordHelper.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Username = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            using (var context = new AppDbContext())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
            
            return "User registered successfully.";
        }
        
        public async Task<bool> Login(string username, string password)
        {
            using (var context = new AppDbContext())
            {
                var user = await context.Users
                    .FirstOrDefaultAsync(u => u.Username == username);

                if (user == null)
                    return false;

                return PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            }
        }
    }
}