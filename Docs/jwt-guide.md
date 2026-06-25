# Hướng dẫn chi tiết nhất về JWT (JSON Web Token) & Lưu trữ Cookie HttpOnly

Tài liệu này cung cấp kiến thức toàn diện về JWT (cấu trúc, cơ chế hoạt động) và phân tích các phương án lưu trữ JWT ở Client, đặc biệt tập trung vào **HttpOnly Cookie** cùng bộ câu hỏi phỏng vấn chuẩn bị cho lập trình viên.

---

## 1. Cấu trúc chuẩn nhất và chi tiết nhất của JWT

Một chuỗi JWT (JSON Web Token) theo tiêu chuẩn **RFC 7519** gồm 3 phần được phân tách bằng dấu chấm (`.`):
$$\text{Header} . \text{Payload} . \text{Signature}$$

```
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOjUsInJvbGUiOiJBZG1pbiIsImV4cCI6MTc4MTcxNzYwMH0.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c
[--------- HEADER ---------] [----------- PAYLOAD -----------] [----------- SIGNATURE -----------]
```

### 1.1. Header (Đầu)
Header chứa siêu dữ liệu về token, được mã hóa dưới dạng **Base64Url**. Nội dung JSON sau khi giải mã thường có dạng:
```json
{
  "alg": "HS256",
  "typ": "JWT"
}
```
* **`alg` (Algorithm)**: Thuật toán mã hóa dùng để ký (ví dụ: `HS256` - HMAC SHA-256, hoặc `RS256` - RSA với SHA-256).
* **`typ` (Type)**: Loại token (luôn là `JWT`).

---

### 1.2. Payload (Thân / Các Claims)
Payload chứa các **Claims** (tuyên bố thông tin về thực thể, ví dụ như thông tin User). Có 3 loại Claims tiêu chuẩn:

#### A. Registered Claims (Các Claim chuẩn hóa quốc tế)
Đây là các claim được định nghĩa sẵn trong tiêu chuẩn RFC 7519. Chúng không bắt buộc nhưng **khuyên dùng để tương thích quốc tế**:
* **`iss` (Issuer)**: Định danh của Server phát hành Token (ví dụ: `api.artify.com`).
* **`sub` (Subject)**: Chủ đề của Token (thường là mã định danh duy nhất của User, ví dụ: `userId`).
* **`aud` (Audience)**: Đối tượng sử dụng Token (ví dụ: `artify.com` hoặc client app).
* **`exp` (Expiration Time)**: Thời điểm hết hạn của Token (được lưu dưới dạng **Unix Timestamp** - số giây tính từ 1/1/1970). Token gửi lên sau thời điểm này sẽ bị từ chối.
* **`nbf` (Not Before)**: Thời điểm Token bắt đầu có hiệu lực. Trước thời điểm này, Token không được chấp nhận.
* **`iat` (Issued At)**: Thời điểm Token được tạo ra.
* **`jti` (JWT ID)**: ID duy nhất cho Token này. Dùng để tránh bị tấn công Replay Attack (Server lưu `jti` này và từ chối nếu nó bị gửi lại).

#### B. Public Claims
Các claim do lập trình viên định nghĩa tự do nhưng nên đăng ký ở Registry của IANA để tránh trùng lặp nếu làm việc đa hệ thống.

#### C. Private Claims
Các claim tự định nghĩa nội bộ giữa Client và Server (ví dụ: `username`, `email`, `role`).
```json
{
  "sub": "1234567890",
  "name": "Nguyen Van A",
  "role": "Admin",
  "exp": 1781717600
}
```
> [!WARNING]
> **Payload chỉ được mã hóa Base64Url chứ không bảo mật thông tin.** Bất kỳ ai cũng có thể giải mã Payload để xem dữ liệu. Tuyệt đối **KHÔNG** lưu thông tin nhạy cảm như Mật khẩu, số thẻ ngân hàng vào đây.

---

### 1.3. Signature (Chữ ký)
Chữ ký dùng để xác minh tính toàn vẹn của Token (đảm bảo Token không bị sửa đổi trên đường truyền). 

Cách tạo Signature:
1. Lấy chuỗi `Header` (Base64Url) và ghép với `Payload` (Base64Url) bằng dấu chấm `.`.
2. Dùng một khóa bí mật (**Secret Key**) chỉ Server biết.
3. Chạy qua thuật toán đã khai báo ở Header (ví dụ: HS256).

$$\text{Signature} = \text{HMACSHA256}(\text{Header} + "." + \text{Payload}, \text{Secret Key})$$

---

## 2. Cơ chế Lưu trữ và Truyền tải JWT ở Client

Khi đưa vào dự án thực tế, bạn phải cân nhắc lưu JWT ở đâu tại Client (Frontend). Dưới đây là phân tích chi tiết:

### 2.1. Phân biệt các hình thức lưu trữ tại Client

| Tiêu chí | LocalStorage / SessionStorage | HttpOnly & Secure Cookie |
| :--- | :--- | :--- |
| **Vị trí lưu** | Bộ nhớ cục bộ của Trình duyệt. | Bộ nhớ Cookie của Trình duyệt. |
| **Cách ghi/đọc** | Sử dụng JavaScript: `localStorage.getItem('token')` | **Server** gửi Header `Set-Cookie`. Trình duyệt tự động nhận và lưu trữ. **JavaScript ở FE không thể đọc/ghi được.** |
| **Cách gửi lên Server** | Phải viết code JS tự đính kèm vào Header `Authorization: Bearer <token>`. | **Trình duyệt tự động đính kèm** vào Header `Cookie` ở mọi Request gửi đến đúng domain của Server. |
| **Chống XSS (Mã độc)** | **Không an toàn**: Nếu hacker chèn được JS vào trang web, chúng sẽ đánh cắp được token. | **An toàn tuyệt đối**: JavaScript không được phép tiếp cận nhờ cờ `HttpOnly`. |
| **Chống CSRF (Giả mạo)** | **An toàn**: Trình duyệt không tự gửi nên hacker không thể giả mạo Request từ trang khác. | **Có rủi ro**: Do cơ chế tự động gửi của trình duyệt. Cần cấu hình `SameSite=Lax` hoặc `Strict` để khắc phục. |

---

### 2.2. Luồng hoạt động chi tiết của HttpOnly Cookie

```mermaid
sequenceDiagram
    participant FE as Client (Trình duyệt)
    participant BE as Server (ASP.NET Core)
    
    FE->>BE: 1. Đăng nhập (POST /api/auth/login)
    BE->>BE: Xác thực & Tạo chuỗi JWT
    BE-->>FE: 2. Trả Response + Header: Set-Cookie: access_token=JWT; HttpOnly; Secure; SameSite=Lax
    Note over FE: Trình duyệt tự nhận cookie này.<br/>JavaScript (Frontend) không thể đọc được chuỗi JWT.
    FE->>BE: 3. Gửi Request cần xác thực (ví dụ: GET /api/profile)
    Note over FE: Trình duyệt tự động đính kèm Cookie chứa JWT vào Header.
    BE->>BE: 4. Server đọc Cookie, giải mã JWT, trả về data profile
    BE-->>FE: 5. Response dữ liệu Profile
```

---

## 3. Kiến trúc Bảo mật Thực tế (Dual Token Best Practice)

Để giải quyết triệt để cả **XSS** lẫn **CSRF**, các hệ thống lớn áp dụng mô hình **Dual Token**:

1. **Access Token (Hạn ngắn: 5 - 15 phút)**:
   * Lưu trong bộ nhớ tạm (**In-Memory** / State của React, Redux, Vue).
   * Dùng để gửi kèm Header `Authorization` khi gọi API.
   * **Vì sao?** Lưu trong bộ nhớ thì miễn nhiễm XSS và không tự động gửi nên cũng miễn nhiễm CSRF. Khi reload trang, Access Token bị mất đi.
2. **Refresh Token (Hạn dài: 7 - 30 ngày)**:
   * Lưu trong **HttpOnly Cookie** (`Secure`, `SameSite=Lax`).
   * Chỉ dùng để gọi 1 API duy nhất: `/api/auth/refresh` nhằm cấp lại Access Token mới khi bị reload trang hoặc khi Access Token cũ hết hạn.

---

## 4. Các câu hỏi phỏng vấn thường gặp về JWT (Cheat Sheet)

> [!TIP]
> Hãy học thuộc các câu hỏi dưới đây để ghi điểm tuyệt đối khi đi phỏng vấn.

### Câu 1: Làm thế nào để hủy (Revoke) một JWT Token khi User đổi mật khẩu hoặc bị khóa tài khoản trước khi Token hết hạn?
* **Trả lời**: Vì JWT hoạt động theo cơ chế Stateless (không lưu trạng thái ở Server), nên mặc định Server sẽ không biết Token đã bị hủy. Có 2 cách xử lý:
  * **Cách 1**: Sử dụng **Blacklist** lưu trên Redis. Khi User logout hoặc bị khóa, đưa `jti` (ID của token) hoặc chuỗi token đó vào Redis với thời gian hết hạn bằng thời hạn còn lại của token. Mỗi khi nhận request, Server kiểm tra xem token có nằm trong Blacklist của Redis không.
  * **Cách 2**: Sử dụng mô hình **Access Token (ngắn hạn)** + **Refresh Token**. Ta chỉ cần vô hiệu hóa Refresh Token trong Database. Sau tối đa 10-15 phút, Access Token cũ hết hạn và không thể làm mới được nữa.

### Câu 2: Signature của JWT được tạo ra để làm gì?
* **Trả lời**: Signature giúp đảm bảo **tính toàn vẹn dữ liệu (Integrity)**. Nó giúp Server phát hiện xem nội dung Payload hoặc Header gửi lên có bị hacker thay đổi hay không. Nếu bị thay đổi, chữ ký được tính toán lại tại Server sẽ không khớp với Signature trên Token, Server sẽ lập tức từ chối.

### Câu 3: Làm sao để chống tấn công CSRF khi lưu JWT trong Cookie?
* **Trả lời**: Để chống CSRF, ta cần:
  1. Cấu hình cờ `SameSite=Lax` hoặc `SameSite=Strict` cho Cookie để ngăn trình duyệt tự động gửi cookie khi có request từ bên thứ ba.
  2. Sử dụng cơ chế Anti-CSRF Token hoặc sử dụng phương pháp Dual Token (chỉ lưu Refresh Token trong cookie, Access Token gửi qua Header Authorization).

### Câu 4: Hãy giải thích các cờ `HttpOnly`, `Secure`, `SameSite` khi cấu hình Cookie?
* **Trả lời**:
  * **`HttpOnly`**: Cấm JavaScript truy cập cookie này, bảo vệ khỏi lỗ hổng XSS.
  * **`Secure`**: Cookie chỉ được gửi qua kết nối HTTPS an toàn.
  * **`SameSite`**: Kiểm soát việc gửi cookie qua các request cross-site:
    * `Strict`: Không gửi cookie trong bất kỳ request cross-site nào.
    * `Lax`: Gửi cookie khi người dùng điều hướng bằng các link thông thường (GET request), không gửi ở các request nguy hiểm của bên thứ 3 (POST, PUT...).
    * `None`: Gửi cookie ở mọi trường hợp (bắt buộc phải đi kèm cờ `Secure`).
