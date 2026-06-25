# Thư mục Contexts (`src/contexts`)

Thư mục này chứa các React Context dùng để quản lý **trạng thái toàn cục (global state)**. Dữ liệu lưu trong Context có thể được truy cập bởi bất kỳ component nào trong ứng dụng mà không cần phải truyền thủ công qua nhiều tầng `props`.

## Các file hiện tại:
*   [AuthContext.jsx](file:///d:/project/FE/src/contexts/AuthContext.jsx): Lưu trữ thông tin đăng nhập của người dùng, token và các hàm xử lý đăng nhập (`login`), đăng xuất (`logout`).

## Cách sử dụng trong component:
```jsx
import { useAuth } from '../contexts/AuthContext';

function MyComponent() {
  const { user, isAuthenticated, logout } = useAuth();
  
  if (!isAuthenticated) return <p>Vui lòng đăng nhập</p>;
  return <button onClick={logout}>Đăng xuất {user.name}</button>;
}
```
