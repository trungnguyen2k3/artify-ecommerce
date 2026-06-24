# Lệnh Scaffold Database First sử dụng dotnet CLI
# Hãy chạy lệnh này trong terminal (PowerShell hoặc CMD) tại thư mục chứa file .csproj:

dotnet ef dbcontext scaffold "Server=localhost\SQLEXPRESS,1433;Database=artify;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext --force
