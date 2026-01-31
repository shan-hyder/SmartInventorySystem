using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartInventorySystem.Data;
using SmartInventorySystem.DTOs;
using SmartInventorySystem.Entities;
using SmartInventorySystem.Interfaces;

namespace SmartInventorySystem.Services
{
    public class AuthService:IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        public AuthService(AppDbContext context,IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public async Task<AuthResponseDTO> UserRegisterAsync(RegisterUserDTO dto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(s => s.Email == dto.Email);
            if (existingUser != null)
            {
                return new AuthResponseDTO
                {
                    success = false,
                    message = "User Already exists"
                };
            }
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                IsActive=true
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

           await  _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return new AuthResponseDTO
            {
                message = "User Registered Successfully",
                success = true
            };
        }
        public async Task<string> UserLoginAsync(LoginDTO dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(s => s.Email == dto.Email && s.IsActive == true);
            if(user!=null)
            {
                var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
                if(result==PasswordVerificationResult.Success)
                {
                    return "Login Successful";
                }
                return "Invalid Password";
            }
            return "User Not Found";
        }
    }
}
