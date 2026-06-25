import React, { useState, useEffect } from 'react';
import { productApi } from '../api/productApi';

const MOCK_PRODUCTS = [
  { id: 1, name: 'Bình Minh Trên Biển', price: 15000000, artist: 'Nguyễn Văn A', image: '🌊', category: 'Tranh Sơn Dầu' },
  { id: 2, name: 'Dáng Ngọc', price: 28000000, artist: 'Trần Thị B', image: '💃', category: 'Điêu Khắc' },
  { id: 3, name: 'Ký Ức Hà Nội', price: 8500000, artist: 'Lê Hoàng C', image: '🏘️', category: 'Tranh Phác Thảo' },
  { id: 4, name: 'Hoàng Hôn Tĩnh Lặng', price: 12000000, artist: 'Nguyễn Văn A', image: '🌅', category: 'Tranh Sơn Dầu' }
];

export default function Products() {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [isUsingMockData, setIsUsingMockData] = useState(false);

  const fetchProducts = async () => {
    setLoading(true);
    setError(null);
    setIsUsingMockData(false);
    try {
      const data = await productApi.getAll();
      // Assume server returns direct array, or enveloped data e.g. { data: [...] }
      const productList = Array.isArray(data) ? data : (data.data || []);
      
      if (productList.length === 0) {
        // If connected but empty, load mock data for demonstration
        setProducts(MOCK_PRODUCTS);
        setIsUsingMockData(true);
      } else {
        setProducts(productList);
      }
    } catch (err) {
      console.warn("Backend API not reachable. Loading mock visual catalog instead.", err);
      setError("Không thể kết nối đến Backend API (.NET). Hệ thống đang hiển thị dữ liệu mẫu để bạn chạy thử giao diện.");
      setProducts(MOCK_PRODUCTS);
      setIsUsingMockData(true);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchProducts();
  }, []);

  const formatPrice = (price) => {
    return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(price);
  };

  return (
    <div className="products-container animate-fade-in">
      <div className="page-header">
        <h2>Danh Sách Tác Phẩm</h2>
        <button onClick={fetchProducts} className="btn btn-secondary-outline">
          🔄 Tải lại dữ liệu
        </button>
      </div>

      {isUsingMockData && error && (
        <div className="alert alert-warning">
          <strong>Thông báo:</strong> {error}
          <br />
          <small>Hãy chắc chắn rằng backend server của bạn tại <code>https://localhost:7246</code> đang chạy.</small>
        </div>
      )}

      {loading ? (
        <div className="loading-spinner">Đang tải sản phẩm...</div>
      ) : (
        <div className="products-grid">
          {products.map((product) => (
            <div key={product.id} className="product-card">
              <div className="product-visual">{product.image || '🖼️'}</div>
              <div className="product-details">
                <span className="product-category">{product.category || 'Nghệ Thuật'}</span>
                <h3>{product.name}</h3>
                <p className="product-artist">Tác giả: {product.artist || 'Ẩn danh'}</p>
                <div className="product-footer">
                  <span className="product-price">{formatPrice(product.price)}</span>
                  <button className="btn btn-primary-sm">Chi tiết</button>
                </div>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}
