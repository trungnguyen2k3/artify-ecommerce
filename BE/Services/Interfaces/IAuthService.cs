using System.Threading.Tasks;
using Artify_ecommerce.DTOs;
using Artify_ecommerce.DTOs.Auth;
using Artify_ecommerce.DTOs.Auth.Requests;
using Artify_ecommerce.DTOs.Auth.Responses;
using Artify_ecommerce.Models;
namespace Artify_ecommerce.Services.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterResponse> RegisterUserAsync(RegisterRequest request);
        Task<Account> ValidateUserAsync(LoginRequest request);
        string GenerateRefreshToken();
        string GenerateJwtToken(Account account, string roleName);
        Task SaveRefreshTokenAsync(Account account, string refreshToken, DateTime expiryTime);
        Task<Account> GetUserByRefreshTokenAsync(string refreshToken);
    }
}
