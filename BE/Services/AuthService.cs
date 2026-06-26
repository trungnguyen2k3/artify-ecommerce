
using Artify_ecommerce.DTOs;
using Artify_ecommerce.DTOs.Auth.Requests;
using Artify_ecommerce.DTOs.Auth.Responses;
using Artify_ecommerce.Exceptions;
using Artify_ecommerce.Helpers;
using Artify_ecommerce.Models;
using Artify_ecommerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Artify_ecommerce.Services
{
    public class AuthService : IAuthService
    {
        public readonly AppDbContext _context;
        public readonly IConfiguration _configuration;
        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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
                CreatedAt = DateTime.UtcNow,
                RoleId = 2, // Mặc định là User
                IsActive = true
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

        public async Task<Account> ValidateUserAsync(LoginRequest request)
        {
            var user = await _context.Accounts.FirstOrDefaultAsync(x => x.Username == request.Username);
            if(user == null || string.IsNullOrEmpty(user.Password) || !PasswordHasher.VerifyPassword(request.Password,user.Password))
            {
                throw new UnauthorizedException("Tên đăng nhập hoặc mật khẩu không chính xác");
            }
            return user;
        }
        public string GenerateJwtToken(Account account, string roleName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.FullName ?? string.Empty),
                new Claim(ClaimTypes.Email, account.Email ?? string.Empty),
                new Claim(ClaimTypes.Role, roleName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:DurationInMinutes"]!)),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task SaveRefreshTokenAsync(Account account, string refreshToken, DateTime expiryTime)
        {
            account.RefreshToken = refreshToken;
            account.RefreshTokenExpiryTime = expiryTime;
            _context.Update(account);
            await _context.SaveChangesAsync();

        }

        public async Task<Account> GetUserByRefreshTokenAsync(string refreshToken)
        {
           var user = await _context.Accounts.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
            if(user == null || user.RefreshTokenExpiryTime == null || user.RefreshTokenExpiryTime < DateTime.UtcNow)
            {
                throw new UnauthorizedException("Phiên làm việc đã hết hạn hoặc Refresh Token không hợp lệ. Vui lòng đăng nhập lại.");
            }
            return user;
        }
    }
}

