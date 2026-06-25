# Thư mục Hooks (`src/hooks`)

Thư mục này chứa các **Custom Hooks** do bạn tự viết. Custom hooks giúp đóng gói các đoạn logic xử lý trạng thái phức tạp (sử dụng `useState`, `useEffect`) thành các hàm độc lập, có thể tái sử dụng dễ dàng trong các Component.

## Các file hiện tại:
*   [useFetch.js](file:///d:/project/FE/src/hooks/useFetch.js): Quản lý trạng thái gọi API tự động (Theo dõi xem dữ liệu đang tải `loading`, lỗi xảy ra `error`, hay đã có kết quả `data`).

## Ví dụ sử dụng `useFetch`:
```jsx
import { useFetch } from '../hooks/useFetch';
import { productApi } from '../api/productApi';

function ProductList() {
  const { data: products, loading, error } = useFetch(productApi.getAll);

  if (loading) return <p>Đang tải...</p>;
  if (error) return <p>Lỗi: {error}</p>;

  return (
    <ul>
      {products.map(p => <li key={p.id}>{p.name}</li>)}
    </ul>
  );
}
```
