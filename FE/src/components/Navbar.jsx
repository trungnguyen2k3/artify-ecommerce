import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useAuth } from '../contexts/AuthContext';

export default function Navbar() {
  const { user, logout, isAuthenticated } = useAuth();
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
    navigate('/');
  };

  return (
    <nav className="navbar">
      <div className="navbar-container">
        <Link to="/" className="navbar-logo">
          Artify <span>Gallery</span>
        </Link>
        <ul className="nav-menu">
          <li className="nav-item">
            <Link to="/" className="nav-links">Trang Chủ</Link>
          </li>
          <li className="nav-item">
            <Link to="/products" className="nav-links">Sản Phẩm</Link>
          </li>
          {isAuthenticated ? (
            <>
              <li className="nav-item user-info">
                <span>Chào, {user?.name || user?.email}</span>
              </li>
              <li className="nav-item">
                <button onClick={handleLogout} className="btn btn-logout">Đăng Xuất</button>
              </li>
            </>
          ) : (
            <li className="nav-item">
              <Link to="/login" className="btn btn-login">Đăng Nhập</Link>
            </li>
          )}
        </ul>
      </div>
    </nav>
  );
}
