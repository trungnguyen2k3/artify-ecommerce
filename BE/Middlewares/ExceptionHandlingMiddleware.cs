using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Artify_ecommerce.Helpers;
using Artify_ecommerce.Exceptions;

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
            
            var statusCode = HttpStatusCode.InternalServerError;
            var errorMessage = "Đã xảy ra lỗi máy chủ nội bộ. Vui lòng thử lại sau.";
            List<string>? errors = null;

            switch (exception)
            {
                case NotFoundException notFoundEx:
                    statusCode = HttpStatusCode.NotFound;
                    errorMessage = notFoundEx.Message;
                    break;
                case BadRequestException badRequestEx:
                    statusCode = HttpStatusCode.BadRequest;
                    errorMessage = badRequestEx.Message;
                    break;
                case ConflictException conflictEx:
                    statusCode = HttpStatusCode.Conflict;
                    errorMessage = conflictEx.Message;
                    break;
                case ForbiddenException forbiddenEx:
                    statusCode = HttpStatusCode.Forbidden;
                    errorMessage = forbiddenEx.Message;
                    break;
                case UnauthorizedException unauthorizedEx:
                    statusCode = HttpStatusCode.Unauthorized;
                    errorMessage = unauthorizedEx.Message;
                    break;
                default:
                    // Đối với các lỗi chưa được xử lý khác, nếu trong môi trường Dev thì hiển thị chi tiết lỗi
                    if (_env.IsDevelopment())
                    {
                        errorMessage = exception.Message;
                        errors = new List<string> { exception.StackTrace ?? string.Empty };
                    }
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
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
