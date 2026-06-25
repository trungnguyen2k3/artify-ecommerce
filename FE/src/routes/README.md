# Thư mục Routes (`src/routes`)

Thư mục này quản lý cấu hình **định tuyến (Routing)** của ứng dụng web, định nghĩa URL nào sẽ tải trang (Page) tương ứng nào.

## Các file hiện tại:
*   [AppRoutes.jsx](file:///d:/project/FE/src/routes/AppRoutes.jsx): Chứa thẻ `<Routes>` và `<Route>` của thư viện `react-router-dom`, bao bọc bố cục layout chung (như Navbar và Footer).

## Cách thêm trang mới vào hệ thống định tuyến:
1. Tạo page mới trong thư mục `src/pages/` (ví dụ: `Cart.jsx`).
2. Mở file `AppRoutes.jsx`, import page vừa tạo.
3. Thêm một thẻ `<Route>` mới vào danh sách:
   ```jsx
   <Route path="/cart" element={<Cart />} />
   ```
