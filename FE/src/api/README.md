# Thư mục API (`src/api`)

Thư mục này quản lý toàn bộ các yêu cầu HTTP gửi tới server Backend. Tất cả các hàm gọi API phải được định nghĩa ở đây để tái sử dụng trên toàn hệ thống và tách biệt hoàn toàn với logic vẽ giao diện.

## Các file hiện tại:
*   [apiClient.js](file:///d:/project/FE/src/api/apiClient.js): Khởi tạo đối tượng Axios dùng chung. Được cấu hình để tự đính kèm token xác thực JWT (nếu có) và xử lý lỗi hệ thống tập trung (như tự động log out khi token hết hạn).
*   [authApi.js](file:///d:/project/FE/src/api/authApi.js): Chứa các request liên quan đến tài khoản (Đăng nhập, Đăng ký, Lấy profile).
*   [productApi.js](file:///d:/project/FE/src/api/productApi.js): Chứa các request liên quan đến sản phẩm (Lấy danh sách, chi tiết, CRUD).

## Hướng dẫn tạo API mới (Ví dụ: `userApi.js`):
1. Tạo file `userApi.js` bên trong thư mục này.
2. Import `apiClient` từ `./apiClient`.
3. Viết và export đối tượng chứa các hàm gọi API:
   ```javascript
   import apiClient from './apiClient';

   export const userApi = {
     getUsers: () => apiClient.get('/users'),
     updateUser: (id, data) => apiClient.put(`/users/${id}`, data)
   };
   ```
