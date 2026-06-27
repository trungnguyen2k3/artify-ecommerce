# CỐT LÕI ASP.NET CORE: KIẾN TRÚC HỆ THỐNG, REST API & GIT BRANDING

> Tài liệu này cung cấp toàn bộ kiến thức nền tảng về cấu trúc hoạt động của ASP.NET Core, quy chuẩn thiết kế REST API chuẩn công nghệ và quy định đặt nhánh Git khi làm việc.

---

## 📅 MỤC LỤC
1. [Chủ đề 1: Kiến thức nền tảng ASP.NET Core (Ẩn dụ "Nhà hàng")](#chủ-đề-1-kiến-thức-nền-tảng-aspnet-core-ẩn-dụ-nhà-hàng)
2. [Chủ đề 2: Tìm hiểu REST API & Các phương thức HTTP tiêu chuẩn](#chủ-đề-2-tìm-hiểu-rest-api--các-phương-thức-http-tiêu-chuẩn)
3. [Chủ đề 3: Quy chuẩn đặt tên nhánh Git & các lệnh làm việc](#chủ-đề-3-quy-chuẩn-đặt-tên-nhánh-git--các-lệnh-làm-việc)

---

## CHỦ ĐỀ 1: KIẾN THỨC NỀN TẢNG ASP.NET CORE (ẨN DỤ "NHÀ HÀNG")

Nếu bạn là người mới bắt đầu học Web, toàn bộ hệ thống ASP.NET Core hoạt động giống như một **Nhà hàng ăn uống**:

| Nhân vật trong nhà hàng | Thành phần trong hệ thống phần mềm | Vai trò & Nhiệm vụ thực tế |
| :--- | :--- | :--- |
| **Khách hàng** | **Trình duyệt FE (Front-end)** | Người đưa ra yêu cầu (muốn xem sản phẩm, muốn đăng nhập). |
| **Thực đơn (Menu)** | **API / URL Endpoint** | Danh sách những gì nhà hàng có thể phục vụ (ví dụ: `GET /api/blogproducts`). |
| **Phiếu gọi món** | **HTTP Request** | Mẩu giấy ghi món ăn khách chọn, kèm yêu cầu thêm (ví dụ: lấy sản phẩm có ID = 1). |
| **Bảo vệ / Người soát vé** | **Middleware** | Đứng ở cửa bếp. Kiểm tra xem khách có mang vé ăn không (Xác thực), hoặc ngăn khách quậy phá (Bắt lỗi). |
| **Bếp trưởng điều phối** | **Controller** | Nhận phiếu gọi món từ bảo vệ, đọc xem khách muốn gì, rồi phân công công việc cho đầu bếp chuyên môn. |
| **Đầu bếp chuyên môn** | **Service** | Người trực tiếp nấu ăn, chế biến nguyên liệu, thực hiện công thức nấu nướng (Logic nghiệp vụ). |
| **Kho nguyên liệu** | **Database (Cơ sở dữ liệu)** | Nơi lưu trữ tất cả dữ liệu thô của hệ thống. |
| **Đĩa thức ăn đã nấu xong** | **HTTP Response (dạng JSON)** | Sản phẩm cuối cùng bưng ra bàn cho khách thưởng thức. |

### 1. Vòng đời của một HTTP Request - Response
Khi Front-end gửi yêu cầu lên Backend, yêu cầu đó đi qua lộ trình khép kín:
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

### 2. Middleware & Pipeline (Đường ống xử lý)
*   **Pipeline (Đường ống)**: Chuỗi các bước xử lý nối tiếp nhau.
*   **Middleware (Mắt xích)**: Từng đoạn ống trong đường ống đó. Mỗi đoạn ống đảm nhận 1 nhiệm vụ duy nhất (ví dụ: đoạn ống 1 lọc nước bẩn, đoạn ống 2 khử trùng).
*   **Ví dụ trong dự án (`ExceptionHandlingMiddleware`):** Đứng ở đầu đường ống làm "Lưới đỡ an toàn" để bắt (catch) mọi lỗi crash code phát sinh đột ngột, giúp hệ thống không bị sập và trả lỗi JSON sạch đẹp cho Client.

### 3. Dependency Injection (DI)
*   **Ẩn dụ "Ổ cắm và Phích cắm":** Ổ cắm trên tường là **Interface** (ví dụ `IBlogProductService`). Phích cắm thiết bị là **Class thực thi** (ví dụ `BlogProductService`). Khi thiết bị hỏng, ta cắm thiết bị khác vào ổ cắm đó mà không cần đập tường đi lại dây điện.
*   DI giúp tách biệt hoàn toàn giữa khai báo dịch vụ và triển khai dịch vụ. Controller chỉ cần khai báo cắm vào Interface, còn hệ thống DI của ASP.NET Core sẽ tự động "bơm" (inject) class thực thi tương ứng vào khi chạy ứng dụng.
*   **3 Vòng đời đối tượng (DI Lifetimes):**
    *   **Transient (Tạm thời):** Cốc nước giấy dùng 1 lần. Cứ yêu cầu là tạo đối tượng mới hoàn toàn.
    *   **Scoped (Theo phiên/Request):** Xe đẩy siêu thị. Một đối tượng duy nhất được tạo ra và dùng chung cho toàn bộ các bước xử lý của một HTTP Request đơn lẻ, sau đó bị hủy. (Thường dùng cho Service và Connection Database).
    *   **Singleton (Độc nhất):** Thang máy tòa nhà. Chỉ một đối tượng duy nhất được tạo ra từ lúc bật Server và dùng chung cho tất cả mọi người mãi mãi.

---

## CHỦ ĐỀ 2: TÌM HIỂU REST API & CÁC PHƯƠNG THỨC HTTP TIÊU CHUẨN

**REST** (Representational State Transfer) là phong cách thiết kế hệ thống mạng dựa trên các tài nguyên (**Resources**). Mỗi tài nguyên có một địa chỉ định danh duy nhất (**URI/URL** - danh từ số nhiều, ví dụ `/api/products`).

### 1. 5 Nguyên tắc cốt lõi của RESTful
1.  **Client - Server (Tách biệt)**: Client lo giao diện, Server lo dữ liệu.
2.  **Stateless (Không trạng thái)**: Server không nhớ phiên làm việc của bạn. Mỗi request gửi lên phải tự chứa đủ thông tin xác thực (JWT Token).
3.  **Cacheable (Bộ nhớ đệm)**: Dữ liệu trả về có thể được trình duyệt lưu tạm để tăng tốc độ truy cập.
4.  **Layered System (Phân lớp)**: Client gọi API không cần biết cấu trúc phía sau của Server (API Gateway, Load Balancer...).
5.  **Uniform Interface (Giao diện đồng nhất)**: Dùng chung chuẩn đặt tên URL và các phương thức HTTP.

### 2. Các phương thức HTTP (HTTP Methods) tiêu chuẩn
*   **GET (Đọc dữ liệu):** 
    *   Chỉ đọc, không làm đổi database.
    *   Có tính lặp lại (Idempotent): gọi nhiều lần kết quả vẫn thế.
    *   Ví dụ: `GET /api/products`, `GET /api/products/15`
*   **POST (Tạo mới tài nguyên):**
    *   Không lặp lại (Non-idempotent): mỗi lần gọi là chèn thêm 1 bản ghi mới vào DB.
    *   Ví dụ: `POST /api/products` (Body: `{"name": "A", "price": 10}`) -> Trả về `201 Created`.
*   **PUT (Cập nhật - Thay thế toàn bộ):**
    *   Thay thế toàn bộ trường của bản ghi. Phải truyền đầy đủ tất cả các trường trong body gửi lên, nếu thiếu trường nào trường đó sẽ bị cập nhật thành NULL dưới database.
    *   Ví dụ: `PUT /api/products/15`
*   **PATCH (Cập nhật - Sửa một phần):**
    *   Chỉ cập nhật một hoặc vài cột cụ thể, các cột khác giữ nguyên. Tiết kiệm băng thông và an toàn hơn PUT.
    *   Ví dụ: `PATCH /api/products/15` (Body: `{"price": 100}`)
*   **DELETE (Xóa bỏ tài nguyên):**
    *   Xóa bản ghi khỏi Database.
    *   Ví dụ: `DELETE /api/products/15` -> Trả về `204 No Content`.

### 3. Các mã trạng thái HTTP (HTTP Status Codes) phổ biến
*   **200 OK**: Thành công, có trả về dữ liệu.
*   **201 Created**: Tạo mới thành công (POST).
*   **204 No Content**: Thành công nhưng không cần trả dữ liệu (DELETE).
*   **400 Bad Request**: Lỗi dữ liệu gửi lên không hợp lệ (Validation).
*   **401 Unauthorized**: Chưa đăng nhập hoặc token sai/hết hạn.
*   **403 Forbidden**: Đã đăng nhập nhưng không đủ quyền hạn (Sai Role).
*   **404 Not Found**: Không tìm thấy tài nguyên yêu cầu (ID không có trong DB).
*   **409 Conflict**: Xung đột dữ liệu (Ví dụ: Trùng tên đăng nhập).
*   **500 Internal Server Error**: Lỗi logic phát sinh ở Backend làm sập code.

---

## CHỦ ĐỀ 3: QUY CHUẨN ĐẶT TÊN NHÁNH GIT & CÁC LỆNH LÀM VIỆC

Đặt tên nhánh (Branch) chuẩn giúp nhóm phát triển dễ quản lý lịch sử code và tương thích tốt với các hệ thống CI/CD tự động.

### 1. Công thức đặt tên Branch chuẩn
$$\text{<category>} / \text{<ticket-id>}-\text{<short-description>}$$

Hoặc (nếu dự án không sử dụng Jira/Trello/Redmine):
$$\text{<category>} / \text{<short-description>}$$

*   **`<category>`**: Phân loại loại công việc (feature, bugfix, hotfix, docs, refactor, chore, test).
*   **`<short-description>`**: Mô tả ngắn gọn bằng tiếng Anh, viết thường, các từ cách nhau bởi dấu gạch ngang `-`.

### 2. Các phân loại nhánh phổ biến
*   `feature/` (hoặc `feat/`): Phát triển tính năng mới. (Ví dụ: `feature/auth-login-cookie`)
*   `bugfix/` (hoặc `fix/`): Sửa một lỗi (bug) phát sinh trong quá trình dev/test. (Ví dụ: `bugfix/fix-null-pointer-blog`)
*   `hotfix/`: Sửa một lỗi cực kỳ khẩn cấp trên môi trường Production.
*   `refactor/`: Tối ưu code cũ nhưng không đổi logic/thêm tính năng. (Ví dụ: `refactor/clean-auth-service`)
*   `docs/`: Viết thêm tài liệu hướng dẫn.

### 3. Các lệnh Git thường dùng khi làm việc với Branch
*   **Cập nhật code mới nhất từ nhánh chính (`main`):**
    ```bash
    git checkout main
    git pull origin main
    ```
*   **Tạo và chuyển sang nhánh mới:**
    ```bash
    git checkout -b feature/auth-jwt-login
    ```
*   **Đẩy nhánh mới lên GitHub lần đầu tiên:**
    ```bash
    git push -u origin feature/auth-jwt-login
    ```
*   **Xóa nhánh local sau khi đã Merge vào main thành công:**
    ```bash
    git checkout main
    git branch -d feature/auth-jwt-login
    ```
