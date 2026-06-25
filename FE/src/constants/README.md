# Thư mục Constants (`src/constants`)

Thư mục này lưu trữ tất cả các biến số, chuỗi ký tự cố định (hằng số) dùng chung trong toàn bộ ứng dụng. Việc gom các biến này lại giúp bạn dễ dàng sửa đổi thông số hệ thống ở một nơi duy nhất.

## Các file hiện tại:
*   [index.js](file:///d:/project/FE/src/constants/index.js): Định nghĩa địa chỉ API của Backend (`API_BASE_URL`) và các phím lưu trữ dữ liệu dưới trình duyệt (`LOCAL_STORAGE_KEYS`).

## Ví dụ sử dụng:
```javascript
import { API_BASE_URL } from '../constants';
console.log("Đường dẫn backend hiện tại:", API_BASE_URL);
```
