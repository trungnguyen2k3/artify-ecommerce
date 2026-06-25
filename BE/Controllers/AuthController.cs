using Artify_ecommerce.DTOs;
using Artify_ecommerce.DTOs.Auth.Requests;
using Artify_ecommerce.DTOs.Auth.Responses;
using Artify_ecommerce.Helpers;
using Artify_ecommerce.Models;
using Artify_ecommerce.Services;
using Artify_ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Artify_ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly AppDbContext _context;
        public AuthController(IAuthService authService, AppDbContext context)
        {
            _authService = authService;
            _context = context;
        }
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<RegisterResponse>>> Register([FromBody] RegisterRequest request)
        {
            var result = await _authService.RegisterUserAsync(request);
            return Ok(new ApiResponse<RegisterResponse>(result,"Đăng kí tài khoản thành công"));
        }
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<LoginResponse>>> Login([FromBody] LoginRequest request)
        {
            // 1. Xác thực thông tin đăng nhập
            var user = await _authService.ValidateUserAsync(request);

            // 2. Tạo Access Token (JWT - ngắn hạn) và Refresh Token (ngẫu nhiên - dài hạn)
            var accessToken = _authService.GenerateJwtToken(user);
            var refreshToken = _authService.GenerateRefreshToken();

            // 3. Lưu Refresh Token vào Database của User (Hạn 7 ngày)
            var refreshTokenExpiry = DateTime.UtcNow.AddDays(7);
            await _authService.SaveRefreshTokenAsync(user, refreshToken, refreshTokenExpiry);

            // 4. Set Refresh Token vào Cookie HttpOnly
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // Set True để chỉ truyền qua HTTPS
                SameSite = SameSiteMode.Lax,
                Expires = refreshTokenExpiry // Khi hết 7 ngày, trình duyệt tự xóa Cookie
            };
            Response.Cookies.Append("refresh_token", refreshToken, cookieOptions);

            // 5. Trả Access Token và User Info về cho FE trong JSON Body
            var responseData = new LoginResponse
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                AccessToken = accessToken
            };

            return Ok(new ApiResponse<LoginResponse>(responseData, "Đăng nhập thành công"));
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<ApiResponse<LoginResponse>>> Refresh()
        {
            // 1. Đọc Refresh Token từ HttpOnly Cookie gửi kèm lên
            var refreshToken = Request.Cookies["refresh_token"];
            if (string.IsNullOrEmpty(refreshToken))
            {
                return Unauthorized(new ApiResponse<object>(null, "Không tìm thấy Refresh Token"));
            }

            try
            {
                // 2. Xác thực Refresh Token dưới Database
                var user = await _authService.GetUserByRefreshTokenAsync(refreshToken);

                // 3. Tạo Access Token mới & Xoay vòng Refresh Token mới (để bảo mật tối đa)
                var newAccessToken = _authService.GenerateJwtToken(user);
                var newRefreshToken = _authService.GenerateRefreshToken();

                // 4. Lưu lại Refresh Token mới vào DB
                var newExpiry = DateTime.UtcNow.AddDays(7);
                await _authService.SaveRefreshTokenAsync(user, newRefreshToken, newExpiry);

                // 5. Ghi Cookie HttpOnly mới đè lên cái cũ
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                    Expires = newExpiry
                };
                Response.Cookies.Append("refresh_token", newRefreshToken, cookieOptions);

                // 6. Trả Access Token mới về cho FE
                var responseData = new LoginResponse
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    AccessToken = newAccessToken
                };

                return Ok(new ApiResponse<LoginResponse>(responseData, "Làm mới Token thành công"));
            }
            catch (Exception ex)
            {
                return Unauthorized(new ApiResponse<object>(null, ex.Message));
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            // Lấy refresh token từ cookie để xóa dưới DB
            var refreshToken = Request.Cookies["refresh_token"];
            if (!string.IsNullOrEmpty(refreshToken))
            {
                var user = await _context.Accounts.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
                if (user != null)
                {
                    // Xóa Refresh Token dưới DB
                    user.RefreshToken = null;
                    user.RefreshTokenExpiryTime = null;
                    await _context.SaveChangesAsync();
                }
            }

            // Xóa Cookie ở trình duyệt Client
            Response.Cookies.Delete("refresh_token");
            return Ok(new ApiResponse<object>(null, "Đăng xuất thành công"));
        }

    }
}
