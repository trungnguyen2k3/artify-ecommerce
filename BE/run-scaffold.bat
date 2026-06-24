@echo off
echo Dang chay EF Core Scaffold tu database 'artify' tren 'localhost\SQLEXPRESS,1433'...
dotnet ef dbcontext scaffold "Server=localhost\SQLEXPRESS,1433;Database=artify;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext --force
if %errorlevel% neq 0 (
    echo [ERROR] Scaffold that bai! Hay chac chan rang SQL Server dang chay va database 'artify' da ton tai.
) else (
    echo [SUCCESS] Scaffold thanh cong! Cac file Models va DbContext da duoc tao trong thu muc Models.
)
pause
