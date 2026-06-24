# Hướng Dẫn Viết và Chạy Unit Test

Thư mục này chứa toàn bộ mã nguồn kiểm thử tự động (Unit Test) cho dự án **Artify-ecommerce**. Dưới đây là giải thích chi tiết, dễ hiểu nhất để bạn làm quen và tự viết tiếp các ca kiểm thử khác.

---

## 1. Unit Test là gì?

**Unit Test (Kiểm thử đơn vị)** là việc viết code để tự động kiểm tra xem các "đơn vị" code nhỏ nhất (thường là các hàm xử lý logic trong Service) có hoạt động đúng thiết kế hay không.

### Quy trình 3 bước chuẩn (AAA Pattern):
Mỗi một hàm test luôn được chia làm 3 phần rõ ràng:
1. **Arrange (Chuẩn bị)**: Thiết lập môi trường, khởi tạo dữ liệu mẫu, chuẩn bị các tham số đầu vào.
2. **Act (Hành động)**: Gọi hàm thực tế cần kiểm tra từ Service/Controller.
3. **Assert (Kiểm chứng)**: Sử dụng các câu lệnh so sánh kết quả thực tế nhận được với kết quả mong đợi.

---

## 2. Các thư viện sử dụng trong dự án

Trong file [Artify-ecommerce.Tests.csproj](file:///d:/project/BE/Artify-ecommerce.Tests/Artify-ecommerce.Tests.csproj), chúng ta có cài đặt các thư viện sau:

| Thư viện | Vai trò / Công dụng |
| :--- | :--- |
| **xUnit** | Framework chạy test. Nó định nghĩa các Annotation như `[Fact]` (đánh dấu một hàm là hàm test) và chạy các hàm đó. |
| **Microsoft.EntityFrameworkCore.InMemory** | Giả lập một Database chạy tạm trên RAM. Giúp chúng ta test các câu lệnh truy vấn database của Entity Framework mà không cần tạo hay kết nối với SQL Server thật, giúp test chạy cực nhanh và độc lập. |
| **FluentAssertions** | Thư viện giúp viết mã kiểm chứng tự nhiên như tiếng Anh. Thay vì viết `Assert.Equal(a, b)`, ta viết `a.Should().Be(b)` rất dễ đọc. |
| **Moq** | Dùng để tạo ra các đối tượng giả (Mock object) cho các Dependency mà lớp cần test phụ thuộc vào (ví dụ giả lập các dịch vụ bên thứ ba gửi mail, SMS...). |

---

## 3. Giải thích chi tiết mã nguồn Test mẫu

Hãy mở file **[BlogProductServiceTests.cs](file:///d:/project/BE/Artify-ecommerce.Tests/BlogProductServiceTests.cs)**:

### A. Khởi tạo Database giả lập (In-Memory Database)
```csharp
private AppDbContext GetInMemoryDbContext()
{
    var options = new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Tên DB ngẫu nhiên để không bị lẫn giữa các test
        .Options;
    return new AppDbContext(options);
}
```
* **Mục đích**: Hàm này tạo ra một DB trống hoàn toàn trên RAM. Do sử dụng `Guid.NewGuid().ToString()`, mỗi khi một hàm test chạy, nó sẽ có một Database riêng biệt và sạch sẽ, không lo bị ảnh hưởng bởi dữ liệu của test khác.

### B. Test Case 1: Lấy sản phẩm thành công
```csharp
[Fact] // Đánh dấu đây là hàm chạy test của xUnit
public async Task GetByIdAsync_WhenProductExists_ReturnsProductDto()
{
    // 1. Arrange (Chuẩn bị)
    using var context = GetInMemoryDbContext();
    var testProduct = new BlogProduct { Id = 1, Name = "Sản phẩm Blog Test", ... };
    context.BlogProducts.Add(testProduct); // Thêm dữ liệu mẫu vào DB ảo trên RAM
    await context.SaveChangesAsync();

    var service = new BlogProductService(context); // Khởi tạo service cần test với DB ảo

    // 2. Act (Thực thi)
    var result = await service.GetByIdAsync(1); // Gọi hàm lấy sản phẩm có ID = 1

    // 3. Assert (Kiểm chứng)
    result.Should().NotBeNull(); // Kết quả trả về không được rỗng
    result.Name.Should().Be(testProduct.Name); // Tên trả về phải trùng khớp tên đã add
}
```

### C. Test Case 2: Xử lý khi sản phẩm không tồn tại (Exception)
```csharp
[Fact]
public async Task GetByIdAsync_WhenProductDoesNotExist_ThrowsNotFoundException()
{
    // 1. Arrange
    using var context = GetInMemoryDbContext(); // DB ảo trống không
    var service = new BlogProductService(context);

    // 2. Act
    Func<Task> act = async () => await service.GetByIdAsync(999); // Gọi lấy ID 999 không có thực

    // 3. Assert
    await act.Should().ThrowAsync<NotFoundException>() // Kiểm tra xem hàm có ném ra lỗi NotFoundException
        .WithMessage("Không tìm thấy sản phẩm Blog có ID = 999"); // Và thông báo lỗi phải khớp 100%
}
```

---

## 4. Cách chạy kiểm thử (Chạy Test)

Bạn có hai cách để chạy kiểm thử:

### Cách 1: Sử dụng Command Line (Nhanh và tiện)
Mở Terminal tại thư mục `d:\project\BE` và chạy lệnh sau:
```bash
dotnet test
```

### Cách 2: Sử dụng Visual Studio hoặc VS Code
* **Trong Visual Studio**: Mở thanh công cụ **Test Explorer** (đường dẫn: *Test > Test Explorer*), sau đó nhấn nút **Run All Tests**.
* **Trong VS Code**: Cài đặt extension **.NET Core Test Explorer**. Bạn sẽ thấy nút "Run Test" hoặc nút Play nhỏ nằm ngay phía trên dòng chữ `[Fact]` để click chạy trực tiếp từng hàm.
