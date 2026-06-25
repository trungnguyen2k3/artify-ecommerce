# SỔ TAY TỰ HỌC: XÂY DỰNG HỆ THỐNG ĐĂNG KÝ & ĐĂNG NHẬP (AUTHENTICATION)

> Tài liệu này hướng dẫn chi tiết cách thiết kế và tự triển khai (code) hệ thống xác thực người dùng (Authentication) cho dự án **Artify eCommerce**. Mọi khái niệm đều đi kèm ẩn dụ thực tế và giải thích bản chất code.

---

## 📅 MỤC LỤC
1. [Phần 1: Ẩn dụ thực tế về Đăng nhập & JWT (Vé xem phim)](#phần-1-ẩn-dụ-thực-tế-về-đăng-nhập--jwt-vé-xem-phim)
2. [Phần 2: Mã hóa mật khẩu với BCrypt](#phần-2-mã-hóa-mật-khẩu-với-bcrypt)
3. [Phần 3: Thiết kế DTOs & Tự động Validate bằng Data Annotations](#phần-3-thiết-kế-dtos--tự-động-validate-bằng-data-annotations)
4. [Phần 4: Lập trình bất đồng bộ (Async / Await) trong luồng Auth](#phần-4-lập-trình-bất-đồng-bộ-async--await-trong-luồng-auth)
5. [Phần 5: Bộ khung code hoàn chỉnh (Skeleton) để tự triển khai](#phần-5-bộ-khung-code-hoàn-chỉnh-skeleton-để-tự-triển-khai)
6. [Phần 6: Lộ trình các bước tự lập trình](#phần-6-lộ-trình-các-bước-tự-lập-trình)

---

## PHẦN 1: ẨN DỤ THỰC TẾ VỀ ĐĂNG NHẬP & JWT (VÉ XEM PHIM)

Để hiểu tại sao hệ thống Web API hiện đại lại dùng JWT (JSON Web Token), hãy so sánh với cách bạn đi xem phim ở rạp:

| Hành động | Tương ứng trong Web API | Cách thức hoạt động |
| :--- | :--- | :--- |
| **Mua vé tại quầy** | **API Đăng nhập (Login)** | Bạn trình chứng minh thư (Username/Password), nhân viên kiểm tra và in cho bạn một **Tấm vé xem phim (JWT Token)**. |
| **Cầm vé đi vào phòng chiếu** | **Gửi kèm Token trong Request Header** | Mỗi lần bạn muốn vào phòng chiếu (gọi API cần bảo mật như xem giỏ hàng, thanh toán), bạn chỉ cần đưa **Tấm vé** ra cho bảo vệ (API Gateway/Middleware). |
| **Bảo vệ kiểm tra vé** | **Xác thực Token (Authentication)** | Bảo vệ nhìn vào dấu mộc và chữ ký của rạp phim trên vé (Chữ ký mật mã `Signature`). Nếu đúng dấu mộc, bạn được vào mà không cần nhân viên phải chạy về kho lục lại CMT của bạn nữa. |

### Tại sao lại chia làm 2 giai đoạn: Làm Login trước, tích hợp JWT sau?
*   **Giai đoạn 1 (Login cơ bản):** Chỉ tập trung vào việc xác nhận "Bạn là ai?" bằng cách đối chiếu thông tin với Database. Nếu đúng, server trả về thông tin User. Việc này giúp bạn kiểm tra kết nối Database và thuật toán kiểm tra mật khẩu đã hoạt động đúng chưa.
*   **Giai đoạn 2 (Tích hợp JWT):** Sau khi xác thực đúng, thay vì chỉ trả về thông tin user thô, server sẽ ký và đóng dấu tạo ra **Tấm vé (JWT Token)** để gửi cho client lưu trữ. Giai đoạn này chỉ tập trung vào cấu hình bảo mật.

---

## PHẦN 2: MÃ HÓA MẬT KHẨU VỚI BCRYPT

### Tại sao không bao giờ được lưu mật khẩu dạng chữ thường (Plain Text)?
Nếu Database của bạn bị hacker đánh cắp, toàn bộ tài khoản người dùng sẽ bị lộ. Do đó, trước khi lưu mật khẩu xuống DB, ta phải **Băm (Hash)** nó thành một chuỗi ký tự kỳ dị không thể dịch ngược lại được.

### Tại sao chọn thuật toán BCrypt?
BCrypt tự động tích hợp **Salt (Muối)** ngẫu nhiên vào chuỗi hash. Kể cả hai người dùng đặt mật khẩu giống hệt nhau là `123456`, chuỗi Hash lưu dưới DB của họ vẫn hoàn toàn khác nhau. Điều này ngăn chặn việc hacker dùng các bảng tra cứu mật khẩu có sẵn để giải mã.

### Cách tổ chức Helper [PasswordHasher.cs](file:///d:/project/BE/Helpers/PasswordHasher.cs) chuẩn dev viết:
```csharp
using BCrypt.Net;

namespace Artify_ecommerce.Helpers
{
    public static class PasswordHasher
    {
        // Nhận vào "123" => Trả về chuỗi hash dị dạng "$2a$11$..." để lưu vào DB
        public static string HashPassword(string password) 
            => BCrypt.Net.BCrypt.HashPassword(password);

        // Nhận vào mật khẩu người dùng nhập và chuỗi hash từ DB => Trả về True/False
        public static bool VerifyPassword(string password, string hashedPassword) 
            => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
```

---

## PHẦN 3: THIẾT KẾ DTOS & TỰ ĐỘNG VALIDATE BẰNG DATA ANNOTATIONS

Để giữ cấu trúc thư mục sạch sẽ, ta tạo thư mục con `Auth` bên trong `DTOs/` để gom nhóm các DTO liên quan lại với nhau.

### 1. `LoginRequest.cs` (Nhận thông tin đăng nhập)
```csharp
using System.ComponentModel.DataAnnotations;

namespace Artify_ecommerce.DTOs.Auth
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; } = string.Empty;
    }
}
```

### 2. `RegisterRequest.cs` (Nhận thông tin đăng ký mới - Bắt buộc mật khẩu phức tạp)
```csharp
using System.ComponentModel.DataAnnotations;

namespace Artify_ecommerce.DTOs.Auth
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên đăng nhập phải từ 3 đến 50 ký tự")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$", 
            ErrorMessage = "Mật khẩu phải dài tối thiểu 6 ký tự, bao gồm ít nhất 1 chữ hoa, 1 chữ thường, 1 chữ số và 1 ký tự đặc biệt.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng")]
        public string Email { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;
    }
}
```

### 3. `UserDto.cs` (Thông tin trả về cho Front-end khi thành công)
```csharp
namespace Artify_ecommerce.DTOs.Auth
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty; // "Admin", "Agent", "Customer"
    }
}
```

---

## PHẦN 4: LẬP TRÌNH BẤT ĐỒNG BỘ (ASYNC / AWAIT) TRONG LUỒNG AUTH

Mọi thao tác đọc ghi Database đều tốn tài nguyên I/O chờ đợi, do đó toàn bộ luồng xử lý trong Service và Controller đều phải thiết lập bất đồng bộ (`async / await`).

### Mô hình luồng chạy bất đồng bộ khi Đăng nhập:

```mermaid
sequenceDiagram
    autonumber
    actor Client
    participant Controller as AuthController (Thread Rảnh)
    participant Service as AuthService
    database DB as Database Server (Đọc Ổ Cứng)

    Client->>Controller: Gọi API /api/auth/login
    Controller->>Service: Gọi LoginAdminAsync(request)
    Note over Service: Gọi EF Core tìm AdminUser
    Service->>DB: await FirstOrDefaultAsync(...)
    Note over Controller: Thread được giải phóng quay về Pool!<br/>Server tiếp tục nhận request khác.
    DB-->>Service: Trả về bản ghi (Tìm thấy User)
    Note over Service: Một Thread rảnh khác nhảy vào chạy tiếp.<br/>Xác thực mật khẩu bằng PasswordHasher.
    Service-->>Controller: Trả về kết quả UserDto
    Controller-->>Client: Trả về HTTP 200 OK + ApiResponse<UserDto>
```

---

## PHẦN 5: BỘ KHUNG CODE HOÀN CHỈNH (SKELETON) ĐỂ TỰ TRIỂN KHAI

### 1. Khung Service Interface: `IAuthService.cs`
Tạo tại: `BE/Services/IAuthService.cs`
```csharp
using System.Threading.Tasks;
using Artify_ecommerce.DTOs.Auth;

namespace Artify_ecommerce.Services
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAdminAsync(RegisterRequest request);
        Task<UserDto> LoginAdminAsync(LoginRequest request);
    }
}
```

### 2. Khung triển khai Service: `AuthService.cs`
Tạo tại: `BE/Services/AuthService.cs`
```csharp
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Artify_ecommerce.Data;
using Artify_ecommerce.DTOs.Auth;
using Artify_ecommerce.Models;
using Artify_ecommerce.Helpers;
using Artify_ecommerce.Exceptions;

namespace Artify_ecommerce.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto> RegisterAdminAsync(RegisterRequest request)
        {
            // Kiểm tra username đã tồn tại chưa
            var exists = await _context.AdminUsers.AnyAsync(u => u.Username == request.Username);
            if (exists)
            {
                throw new ConflictException("Tên đăng nhập đã tồn tại.");
            }

            // Mã hóa mật khẩu
            var hashed = PasswordHasher.HashPassword(request.Password);

            var admin = new AdminUser
            {
                Username = request.Username,
                PasswordHash = hashed,
                DisplayName = string.IsNullOrEmpty(request.DisplayName) ? request.Username : request.DisplayName,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.AdminUsers.Add(admin);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Id = admin.Id,
                Username = admin.Username,
                DisplayName = admin.DisplayName,
                UserType = "Admin"
            };
        }

        public async Task<UserDto> LoginAdminAsync(LoginRequest request)
        {
            var admin = await _context.AdminUsers.FirstOrDefaultAsync(u => u.Username == request.Username);
            
            if (admin == null || !admin.IsActive)
            {
                throw new UnauthorizedException("Tài khoản không tồn tại hoặc đã bị khóa.");
            }

            var isValid = PasswordHasher.VerifyPassword(request.Password, admin.PasswordHash);
            if (!isValid)
            {
                throw new UnauthorizedException("Mật khẩu không chính xác.");
            }

            admin.LastLoginAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Id = admin.Id,
                Username = admin.Username,
                DisplayName = admin.DisplayName,
                UserType = "Admin"
            };
        }
    }
}
```

### 3. Khung Controller: `AuthController.cs`
Tạo tại: `BE/Controllers/AuthController.cs`
```csharp
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Artify_ecommerce.DTOs.Auth;
using Artify_ecommerce.Helpers;
using Artify_ecommerce.Services;

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

        [HttpPost("register/admin")]
        public async Task<ActionResult<ApiResponse<UserDto>>> RegisterAdmin([FromBody] RegisterRequest request)
        {
            var result = await _authService.RegisterAdminAsync(request);
            return Ok(new ApiResponse<UserDto>(result, "Đăng ký tài khoản Admin thành công."));
        }

        [HttpPost("login/admin")]
        public async Task<ActionResult<ApiResponse<UserDto>>> LoginAdmin([FromBody] LoginRequest request)
        {
            var result = await _authService.LoginAdminAsync(request);
            return Ok(new ApiResponse<UserDto>(result, "Đăng nhập thành công."));
        }
    }
}
```

---

## PHẦN 6: LỘ TRÌNH CÁC BƯỚC TỰ LẬP TRÌNH

Sau khi bạn đã chuẩn bị xong các file code theo các bộ khung trên:

1.  **Đăng ký Service vào Dependency Injection:**
    Mở file [DependencyInjection.cs](file:///d:/project/BE/Extensions/DependencyInjection.cs) và bổ sung dòng đăng ký dịch vụ vào phần số 3:
    ```csharp
    services.AddScoped<IAuthService, AuthService>();
    ```
2.  **Khởi động ứng dụng Backend:**
    Chạy lệnh khởi động dự án hoặc nhấn F5 (Debug).
3.  **Test API Đăng ký:**
    Mở trình duyệt truy cập `/swagger/index.html` (hoặc Postman), gọi API `POST /api/auth/register/admin` với dữ liệu mẫu dạng JSON:
    ```json
    {
      "username": "admin01",
      "password": "Password123!",
      "email": "admin@example.com",
      "displayName": "Quản Trị Viên 01"
    }
    ```
4.  **Kiểm tra Database:**
    Kiểm tra bảng `AdminUser` xem tài khoản đã được chèn vào chưa và kiểm tra cột `PasswordHash` có lưu đúng chuỗi đã được mã hóa không.
5.  **Test API Đăng nhập:**
    Gọi API `POST /api/auth/login/admin` truyền đúng tài khoản/mật khẩu vừa tạo để xác nhận đăng nhập thành công.
