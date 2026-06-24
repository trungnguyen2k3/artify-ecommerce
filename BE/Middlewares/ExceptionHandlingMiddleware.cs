using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Artify_ecommerce.Helpers;

namespace Artify_ecommerce.Middlewares
{
    /// <summary>
    /// Middleware xử lý lỗi tập trung (Global Exception Handler)
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Đã xảy ra lỗi hệ thống không kiểm soát: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorMessage = "Đã xảy ra lỗi máy chủ nội bộ. Vui lòng thử lại sau.";
            List<string>? errors = null;

            // Nếu đang chạy ở môi trường Development, hiển thị chi tiết stack trace để debug dễ dàng hơn
            if (_env.IsDevelopment())
            {
                errorMessage = exception.Message;
                errors = new List<string> { exception.StackTrace ?? string.Empty };
            }

            var response = new ApiResponse(errorMessage, errors);

            var jsonOptions = new JsonSerializerOptions 
            { 
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
            };
            
            var json = JsonSerializer.Serialize(response, jsonOptions);
            await context.Response.WriteAsync(json);
        }
    }
}
