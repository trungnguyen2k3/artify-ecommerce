
using Artify_ecommerce.DTOs;
using Artify_ecommerce.DTOs.Auth.Responses;
using Artify_ecommerce.Exceptions;
using Artify_ecommerce.Helpers;
using Artify_ecommerce.Models;
using Artify_ecommerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artify_ecommerce.Services
{
    public class AuthService : IAuthService
    {
        public readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RegisterResponse> RegisterUserAsync(RegisterRequest request)
        {
            var user = await _context.Accounts.FirstOrDefaultAsync(x => x.Username == request.Username);
            if(user != null)
            {
                throw new ConflictException("Tài khoản đã tồn tại, vui lòng đăng kí tài khoản khác");
            }
            var hashpassword = PasswordHasher.HashPassword(request.Password);
            var newUser = new Account
            {
                Username = request.Username,
                Password = hashpassword, 
                Email = request.Email,
                FullName = request.Username,  
                GoogleId = "local",  
                CreatedAt = DateTime.UtcNow
            };
            _context.Accounts.Add(newUser);
            await _context.SaveChangesAsync();
            return new RegisterResponse
            {
                Id = newUser.Id,
                Username = newUser.Username,
                Email = newUser.Email,
                CreatedAt = newUser.CreatedAt
            };
        }
}
}

