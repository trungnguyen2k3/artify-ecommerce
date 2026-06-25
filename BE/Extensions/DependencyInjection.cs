using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Artify_ecommerce.Data;
using Artify_ecommerce.Services;
using Artify_ecommerce.Services.Interfaces;

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
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // 3. Đăng ký các service nghiệp vụ khác ở đây (ví dụ: Service, Repository)
            services.AddScoped<IBlogProductService, BlogProductService>();
            //services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
