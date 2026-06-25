using Artify_ecommerce.DTOs;
using Artify_ecommerce.DTOs.Auth.Responses;
using Artify_ecommerce.Helpers;
using Artify_ecommerce.Services;
using Artify_ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Artify_ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<RegisterResponse>>> Register([FromBody] RegisterRequest request)
        {
            var result = await _authService.RegisterUserAsync(request);
            return Ok(new ApiResponse<RegisterResponse>(result,"Đăng kí tài khoản thành công"));
        }
    }
}
