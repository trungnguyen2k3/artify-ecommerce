import React from 'react';
import { Link } from 'react-router-dom';

export default function Home() {
  return (
    <div className="home-container animate-fade-in">
      <header className="hero-section">
        <div className="hero-content">
          <h1>Chào mừng tới Artify Gallery</h1>
          <p>Khám phá và sở hữu các tác phẩm nghệ thuật độc bản từ các nghệ sĩ danh tiếng.</p>
          <div className="hero-actions">
            <Link to="/products" className="btn btn-primary">Khám Phá Ngay</Link>
          </div>
        </div>
      </header>

      <section className="featured-section">
        <h2>Bộ Sưu Tập Nổi Bật</h2>
        <div className="features-grid">
          <div className="feature-card">
            <div className="feature-img painting-placeholder">🖼️</div>
            <h3>Tranh Sơn Dầu</h3>
            <p>Sự kết hợp hoàn mỹ giữa chất liệu cổ điển và hơi thở đương đại.</p>
          </div>
          <div className="feature-card">
            <div className="feature-img sculpture-placeholder">🗿</div>
            <h3>Điêu Khắc</h3>
            <p>Những hình khối 3D đầy tính biểu đạt sáng tạo.</p>
          </div>
          <div className="feature-card">
            <div className="feature-img sketch-placeholder">✍️</div>
            <h3>Tranh Phác Thảo</h3>
            <p>Nét vẽ tinh tế, lưu giữ trọn vẹn cảm xúc chân thật nhất.</p>
          </div>
        </div>
      </section>
    </div>
  );
}
