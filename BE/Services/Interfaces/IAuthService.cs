using System.Threading.Tasks;
using Artify_ecommerce.DTOs;
using Artify_ecommerce.DTOs.Auth;
using Artify_ecommerce.DTOs.Auth.Responses;
namespace Artify_ecommerce.Services.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterResponse> RegisterUserAsync(RegisterRequest request);
    }
}
