# Thư mục Components (`src/components`)

Thư mục này chứa các thành phần giao diện nhỏ, có tính **tái sử dụng cao** và dùng chung ở nhiều trang khác nhau (ví dụ: Nút bấm, Ô nhập liệu, Header, Footer, Hộp thoại báo lỗi...).

## Các file hiện tại:
*   [Navbar.jsx](file:///d:/project/FE/src/components/Navbar.jsx): Thanh điều hướng (Header menu) ở đầu trang.
*   [Footer.jsx](file:///d:/project/FE/src/components/Footer.jsx): Phần chân trang chứa bản quyền và thông tin dự án.

## Quy tắc thiết kế Component:
*   **Hạn chế tự quản lý state lớn:** Một component dùng chung nên nhận dữ liệu qua `props` thay vì tự gọi API (trừ trường hợp đặc biệt như Navbar cần lấy thông tin user đăng nhập).
*   **Chia nhỏ:** Nếu một component trở nên quá dài (trên 200 dòng), hãy cân nhắc chia nhỏ nó thành các component con.
