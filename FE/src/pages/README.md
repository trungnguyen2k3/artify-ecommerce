# Thư mục Pages (`src/pages`)

Thư mục này chứa các component đại diện cho một **Trang hoàn chỉnh** trong ứng dụng (tương ứng với một đường dẫn URL nhất định).

## Các file hiện tại:
*   [Home.jsx](file:///d:/project/FE/src/pages/Home.jsx): Trang chủ giới thiệu phòng trưng bày nghệ thuật.
*   [Products.jsx](file:///d:/project/FE/src/pages/Products.jsx): Trang danh sách sản phẩm/tác phẩm nghệ thuật có kết nối API.
*   [Login.jsx](file:///d:/project/FE/src/pages/Login.jsx): Trang đăng nhập hệ thống.

## Khác biệt giữa Page và Component:
*   **Page:** Nằm ở thư mục này, đảm nhận vai trò quản lý vòng đời của cả trang, gọi các API để lấy dữ liệu lớn, xử lý query parameters từ URL và sắp xếp các Component con.
*   **Component (ở thư mục `components`):** Chỉ làm nhiệm vụ hiển thị giao diện dựa trên dữ liệu (`props`) nhận được từ Page hoặc xử lý tương tác nhỏ của chính nó.
