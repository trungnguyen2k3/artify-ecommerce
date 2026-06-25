using Artify_ecommerce.Extensions;
using Artify_ecommerce.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.Configure<RouteOptions>(options => 
{
    options.LowercaseUrls = true; // Tự động chuyển toàn bộ URL API thành chữ thường
});
// Đăng ký các dịch vụ hệ thống thông qua Dependency Injection Extension
builder.Services.AddWebApiServices(builder.Configuration);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register Swagger/OpenAPI generators
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "Artify eCommerce API",
        Version = "v1",
        Description = "API for Artify eCommerce platform"
    });
});

var app = builder.Build();

// Kích hoạt Middleware xử lý lỗi toàn cục đầu tiên trong pipeline để bắt mọi exception
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    // Enable Swagger and Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Artify eCommerce API v1");
        options.RoutePrefix = "swagger"; // Access Swagger UI at root or /swagger
    });
}

app.UseHttpsRedirection();

// Kích hoạt chính sách CORS
app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
