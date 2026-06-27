using Artify_ecommerce.Models;
using Artify_ecommerce.Services;
using Artify_ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Artify_ecommerce.Extensions
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Đăng ký các dịch vụ cốt lõi của ứng dụng REST API
        /// </summary>
        public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Cấu hình DbContext kết nối SQL Server
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // 2. Cấu hình CORS để Frontend dễ dàng kết nối tới API
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.WithOrigins("http://localhost:3000", "http://localhost:5173")
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials();
                });
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };

                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async context =>
                    {
                        var dbContext = context.HttpContext.RequestServices.GetRequiredService<AppDbContext>();
                        var userIdClaim = context.Principal?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                        
                        if (userIdClaim != null && int.TryParse(userIdClaim, out var userId))
                        {
                            var user = await dbContext.Accounts.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
                            if (user == null || !user.IsActive)
                            {
                                context.Fail("Tài khoản đã bị khóa hoặc không tồn tại.");
                            }
                        }
                    }
                };
            });

            services.AddScoped<IBlogProductService, BlogProductService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
