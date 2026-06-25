# SỔ TAY TỰ HỌC BACKEND ASP.NET CORE (TỪ CON SỐ 0)

> Tài liệu này được biên soạn đặc biệt dành cho người mới bắt đầu. Mọi khái niệm phức tạp đều được giải thích bằng ví dụ thực tế đời sống, hình ảnh ẩn dụ trực quan và đối chiếu trực tiếp với mã nguồn có sẵn trong dự án **Artify eCommerce** của bạn.

---

## 📅 MỤC LỤC
1. [Phần 0: Nhập môn cho người chưa biết gì (Ẩn dụ "Nhà hàng")](#phần-0-nhập-môn-cho-người-chưa-biết-gì-ẩn-dụ-nhà-hàng)
2. [Phần 1: Vòng đời của một HTTP Request - Response](#phần-1-vòng-đời-của-một-http-request---response)
3. [Phần 2: Middleware & Pipeline (Đường ống xử lý là gì?)](#phần-2-middleware--pipeline-đường-ống-xử-lý-là-gì)
4. [Phần 3: Dependency Injection (DI) - Tại sao phải dùng?](#phần-3-dependency-injection-di---tại-sao-phải-dùng)
5. [Phần 4: 3 Loại Vòng đời đối tượng (DI Lifetimes)](#phần-4-3-loại-vòng-đời-đối-tượng-di-lifetimes)
6. [Phần 5: Thuật ngữ bổ trợ cho người mới bắt đầu](#phần-5-thuật-ngữ-bổ-trợ-cho-người-mới-bắt-đầu)
7. [Phần 6: Thực hành Debug từng bước để thấy code chạy](#phần-6-thực-hành-debug-từng-bước-để-thấy-code-chạy)

---

## PHẦN 0: NHẬP MÔN CHO NGƯỜI CHƯA BIẾT GÌ (ẨN DỤ "NHÀ HÀNG")

Nếu bạn chưa từng học về lập trình Web, hãy tưởng tượng toàn bộ hệ thống phần mềm hoạt động giống như một **Nhà hàng ăn uống**:

| Nhân vật trong nhà hàng | Thành phần trong hệ thống phần mềm | Vai trò & Nhiệm vụ thực tế |
| :--- | :--- | :--- |
| **Khách hàng** | **Trình duyệt FE (Front-end)** | Người đưa ra yêu cầu (muốn xem sản phẩm, muốn đăng nhập). |
| **Thực đơn (Menu)** | **API / URL Endpoint** | Danh sách những gì nhà hàng có thể phục vụ (ví dụ: `GET /api/blogproducts`). |
| **Phiếu gọi món** | **HTTP Request** | Mẩu giấy ghi món ăn khách chọn, kèm yêu cầu thêm (ví dụ: lấy sản phẩm có ID = 1). |
| **Bảo vệ / Người soát vé** | **Middleware** | Đứng ở cửa bếp. Kiểm tra xem khách có mang vé ăn không (Xác thực), hoặc ngăn khách quậy phá (Bắt lỗi). |
| **Bếp trưởng điều phối** | **Controller** | Nhận phiếu gọi món từ bảo vệ, đọc xem khách muốn gì, rồi phân công công việc cho đầu bếp chuyên môn. |
| **Đầu bếp chuyên môn** | **Service** | Người trực tiếp nấu ăn, chế biến nguyên liệu, thực hiện công thức nấu nướng (Logic nghiệp vụ). |
| **Kho nguyên liệu** | **Database (Cơ sở dữ liệu)** | Nơi lưu trữ tất cả thịt, rau, củ, quả (dữ liệu thô của hệ thống). |
| **Đĩa thức ăn đã nấu xong** | **HTTP Response (dạng JSON)** | Sản phẩm cuối cùng bưng ra bàn cho khách thưởng thức. |

---

## PHẦN 1: VÒNG ĐỜI CỦA MỘT HTTP REQUEST - RESPONSE

Khi Front-end gửi một yêu cầu lên Backend, yêu cầu đó phải đi qua một lộ trình khép kín.

### Sơ đồ chi tiết đường đi của dữ liệu:

```mermaid
sequenceDiagram
    autonumber
    actor FE as Front-end (Khách hàng)
    participant MW as Middleware (Bảo vệ soát vé)
    participant Ctrl as Controller (Bếp trưởng)
    participant Svc as Service (Đầu bếp)
    database DB as Database (Kho nguyên liệu)

    FE->>MW: 1. Gửi Request (Muốn lấy sản phẩm ID = 1)
    Note over MW: Kiểm tra an toàn bảo mật
    MW->>Ctrl: 2. Chuyển Request hợp lệ vào bếp
    Ctrl->>Svc: 3. Ra lệnh: "Lấy sản phẩm ID=1 cho tôi"
    Svc->>DB: 4. Vào kho truy vấn tìm bản ghi
    DB-->>Svc: 5. Trả về dữ liệu thô từ bảng
    Note over Svc: Chuyển dữ liệu thô sang DTO gọn đẹp
    Svc-->>Ctrl: 6. Trả về món ăn (DTO) đã nấu xong
    Ctrl-->>MW: 7. Đóng gói đĩa thức ăn thành JSON (Response)
    Note over MW: Nếu có lỗi dọc đường, đóng gói lỗi tại đây
    MW-->>FE: 8. Trả Response về cho người dùng hiển thị
```

---

## PHẦN 2: MIDDLEWARE & PIPELINE (ĐƯỜNG ỐNG XỬ LÝ LÀ GÌ?)

### Khái niệm cơ bản
* **Pipeline (Đường ống)**: Là một chuỗi các bước xử lý nối tiếp nhau.
* **Middleware (Mắt xích)**: Là từng đoạn ống trong đường ống đó. Mỗi đoạn ống đảm nhận 1 nhiệm vụ duy nhất (ví dụ: đoạn ống 1 lọc nước bẩn, đoạn ống 2 khử trùng, đoạn ống 3 thêm khoáng chất).

### Dẫn chứng trong dự án của bạn: `ExceptionHandlingMiddleware`
Mở file nguồn: [ExceptionHandlingMiddleware.cs](file:///d:/project/BE/Middlewares/ExceptionHandlingMiddleware.cs)

Bình thường, nếu code của bạn bị lỗi (ví dụ Database bị sập), chương trình C# sẽ dừng hoạt động và ném ra một màn hình lỗi đỏ ngòm. Để tránh điều này, ta dùng **ExceptionHandlingMiddleware** làm **"Lưới đỡ an toàn"** đứng ở đầu đường ống.

#### Cách nó hoạt động ngầm (Quy ước của C#):
Bạn sẽ thắc mắc: *"Tại sao không thấy nó kế thừa từ class nào mà C# vẫn biết nó là Middleware?"*
Vì ASP.NET Core quy định: Chỉ cần Class của bạn có:
1. Một biến `RequestDelegate _next` trong constructor (để biết đoạn ống tiếp theo ở đâu).
2. Một hàm tên là `InvokeAsync(HttpContext context)` nhận thông tin cuộc gọi.

Hệ thống sẽ tự động coi nó là Middleware và kích hoạt nó đầu tiên trong file [Program.cs](file:///d:/project/BE/Program.cs#L30):
```csharp
app.UseMiddleware<ExceptionHandlingMiddleware>();
```

---

## PHẦN 3: DEPENDENCY INJECTION (DI) - TẠI SAO PHẢI DÙNG?

### Ẩn dụ về "Ổ cắm và Phích cắm"
Hãy tưởng tượng trên bức tường nhà bạn có một **Ổ cắm điện 3 chấu** (đây là **Interface**).
Bạn có một cái quạt có **Phích cắm 3 chấu** (đây là **Class thực thi - Service**).

* Khi cắm quạt vào ổ điện, quạt chạy bình thường.
* Ngày mai quạt hỏng, bạn mua một cái máy hút bụi cũng có **Phích cắm 3 chấu**. Bạn chỉ việc cắm máy hút bụi vào chính ổ cắm đó mà không cần đập bức tường ra để đi lại đường dây điện.

Trong lập trình, **Dependency Injection (DI)** giúp bạn làm điều tương tự. Controller chỉ cần cắm vào **Ổ cắm (Interface `IBlogProductService`)**, còn việc thiết bị cụ thể nào chạy bên dưới (**Class `BlogProductService`**) sẽ do hệ thống tự "bơm" (inject) vào.

### So sánh cách viết:

#### Cách viết cũ (Không dùng DI - Rất tệ):
```csharp
// Controller tự tạo dịch vụ bằng từ khóa new
public class BlogProductsController : ControllerBase
{
    private readonly BlogProductService _service;

    public BlogProductsController()
    {
        // Tự tạo bằng tay. Nếu BlogProductService thay đổi cấu trúc, dòng này sẽ bị lỗi!
        _service = new BlogProductService(new AppDbContext()); 
    }
}
```

#### Cách viết mới (Dùng DI - Rất sạch):
```csharp
public class BlogProductsController : ControllerBase
{
    private readonly IBlogProductService _blogProductService;

    // Chỉ yêu cầu: "Tôi cần một thiết bị cắm vừa ổ IBlogProductService"
    public BlogProductsController(IBlogProductService blogProductService)
    {
        _blogProductService = blogProductService; 
    }
}
```

---

## PHẦN 4: 3 LOẠI VÒNG ĐỜI ĐỐI TƯỢNG (DI LIFETIMES)

Khi đăng ký các dịch vụ với hệ thống tại [DependencyInjection.cs](file:///d:/project/BE/Extensions/DependencyInjection.cs), bạn cần chọn cách hệ thống tạo ra và hủy đối tượng đó.

### 1. Transient (Tạm thời) - `services.AddTransient<T, Implementation>()`
* **Triết lý**: Cứ gọi là tạo mới, không dùng lại đồ cũ.
* **Ẩn dụ**: **Cốc nước giấy dùng 1 lần**. Bạn khát nước $\rightarrow$ rút cốc mới $\rightarrow$ uống $\rightarrow$ vứt thùng rác. Người sau khát $\rightarrow$ rút cốc mới khác.

### 2. Scoped (Theo phiên làm việc) - `services.AddScoped<T, Implementation>()`
* **Triết lý**: Tạo 1 lần duy nhất cho mỗi lượt truy cập (Request) của một người dùng.
* **Ẩn dụ**: **Xe đẩy trong siêu thị**.
  * **User A** vào siêu thị (gửi Request) $\rightarrow$ lấy xe đẩy A $\rightarrow$ mua sắm $\rightarrow$ thanh toán ra về $\rightarrow$ trả xe (xe bị hủy/dọn dẹp).
  * **User B** vào siêu thị $\rightarrow$ lấy xe đẩy B hoàn toàn độc lập với xe A.
* **Tại sao hầu hết Service dùng cái này?** Vì kết nối Database (`DbContext`) là Scoped. Service dùng chung DbContext cũng phải là Scoped để dữ liệu của User A không bị trộn lẫn hay ghi đè lên dữ liệu của User B.

### 3. Singleton (Độc nhất) - `services.AddSingleton<T, Implementation>()`
* **Triết lý**: Tạo 1 lần duy nhất khi bật server và dùng chung cho tất cả mọi người, mãi mãi.
* **Ẩn dụ**: **Thang máy tòa nhà**. Chỉ có một cái thang máy duy nhất chạy lên chạy xuống, tất cả mọi người (User A, User B...) đều bước vào chung một cái thang máy đó để di chuyển.

---

## PHẦN 5: THUẬT NGỮ BỔ TRỢ CHO NGƯỜI MỚI BẮT ĐẦU

Để đọc hiểu các tài liệu kỹ thuật, bạn cần nắm chắc các khái niệm sau:

1. **Exception (Ngoại lệ)**: Là một lỗi xảy ra khi chương trình đang chạy làm gián đoạn luồng bình thường của ứng dụng (ví dụ: tìm không thấy dữ liệu, lỗi chia cho số 0, mất kết nối mạng).
2. **StackTrace (Vết theo dõi lỗi)**: Giống như "hộp đen" của máy bay. Khi chương trình bị crash, StackTrace sẽ ghi lại danh sách các dòng code, các hàm đã chạy qua trước khi gặp lỗi, giúp lập trình viên biết chính xác lỗi ở dòng số mấy, file nào.
3. **Serialization (Tuần tự hóa)**: Hành động chuyển đổi một đối tượng trong bộ nhớ C# thành một chuỗi văn bản (thường là định dạng JSON) để gửi qua mạng Internet cho Front-end.
4. **Deserialization (Giải tuần tự hóa)**: Ngược lại với trên, chuyển chuỗi văn bản nhận được từ Internet thành đối tượng trong bộ nhớ để code xử lý.
5. **DTO (Data Transfer Object)**: Đối tượng chuyển truyền dữ liệu. Thường là một class trung gian chứa các thông tin rút gọn, sạch sẽ để trả về cho Front-end thay vì trả về toàn bộ bảng dữ liệu thô (Entity) trong Database nhằm bảo mật thông tin.

---

## PHẦN 6: THỰC HÀNH DEBUG TỪNG BƯỚC ĐỂ THẤY CODE CHẠY

Lý thuyết sẽ mãi là lý thuyết nếu bạn không nhìn thấy nó hoạt động. Hãy làm theo 5 bước sau để thấy toàn bộ các khái niệm trên vận hành:

1. **Đặt Điểm Dừng (Breakpoint)**:
   * Mở [BlogProductsController.cs](file:///d:/project/BE/Controllers/BlogProductsController.cs). Nhấp chuột vào lề xám bên trái của dòng 31: `var result = await _blogProductService.GetByIdAsync(id);` (sẽ xuất hiện 1 chấm đỏ).
   * Mở [BlogProductService.cs](file:///d:/project/BE/Services/BlogProductService.cs). Đặt 1 chấm đỏ ở dòng 28: `if (blogProduct == null)`.
   * Mở [ExceptionHandlingMiddleware.cs](file:///d:/project/BE/Middlewares/ExceptionHandlingMiddleware.cs). Đặt 1 chấm đỏ ở dòng 36: `catch (Exception ex)` và dòng 84: `var response = new ApiResponse(errorMessage, errors);`.

2. **Chạy Chế Độ Debug**:
   * Nhấn phím **F5** trên bàn phím để khởi chạy Backend ở chế độ gỡ lỗi (Debug).

3. **Gửi Request lỗi**:
   * Sử dụng Postman hoặc trình duyệt web, truy cập đường dẫn lỗi sau (ví dụ ID = 9999 không tồn tại):
     `https://localhost:7119/api/blogproducts/9999` (Lưu ý thay đúng cổng Port của bạn).

4. **Theo dõi luồng nhảy của Code**:
   * **Lần 1**: Chương trình sẽ khựng lại ở dòng 31 của Controller (chấm đỏ sáng lên).
   * **Lần 2**: Nhấn nút **Step Into (F11)**, bạn sẽ thấy code nhảy lập tức vào dòng 24 của file Service để truy vấn database. Nhấn tiếp **Step Over (F10)** để đi xuống dòng `if (blogProduct == null)`.
   * **Lần 3**: Vì ID 9999 không tồn tại, code đi vào trong và chạy lệnh `throw new NotFoundException(...)`. Nhấn **Step Over (F10)** một lần nữa.
   * **Lần 4**: Bạn sẽ thấy luồng code biến mất khỏi Service và tự động nhảy vọt ra file Middleware tại dòng `catch (Exception ex)`.
   * **Lần 5**: Nhấn **F10** tiếp, code chạy xuống dòng khởi tạo `new ApiResponse(errorMessage, errors)`. Tại đây thuộc tính `Success` được gán bằng `false`.
   * **Lần 6**: Nhấn **F5** để chạy nốt phần còn lại. Kiểm tra màn hình Postman, bạn sẽ thấy nhận về đúng JSON lỗi sạch sẽ.
