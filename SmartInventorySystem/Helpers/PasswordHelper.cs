using Microsoft.AspNetCore.Identity;
using SmartInventorySystem.Entities;

namespace SmartInventorySystem.Helpers
{
    public class PasswordHelper
    {
        private static readonly PasswordHasher<User> _hasher = new();

        public static string HashPassword(User user,string Password)
        //=> _hasher.HashPassword(user, Password);simple delegate syntax
        {
            return _hasher.HashPassword(user, Password);
        }
        public static bool VerifyPassword(User user,string Password)
        {
            return _hasher.VerifyHashedPassword(user, user.PasswordHash,Password)
                == PasswordVerificationResult.Success;
        }
    }
}
