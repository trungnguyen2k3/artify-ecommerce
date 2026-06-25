import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../contexts/AuthContext';

export default function Login() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [formError, setFormError] = useState('');
  const { login, loading, error: authError } = useAuth();
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setFormError('');

    if (!email || !password) {
      setFormError('Vui lòng điền đầy đủ Email và Mật khẩu.');
      return;
    }

    try {
      await login(email, password);
      navigate('/');
    } catch (err) {
      // Error handled by context or can be custom caught here
      console.error("Login attempt failed:", err);
    }
  };

  return (
    <div className="login-page animate-fade-in">
      <div className="login-card">
        <h2>Đăng Nhập</h2>
        <p className="login-subtitle">Chào mừng bạn trở lại với Artify Gallery</p>
        
        {(formError || authError) && (
          <div className="alert alert-danger">
            {formError || authError}
          </div>
        )}

        <form onSubmit={handleSubmit} className="login-form">
          <div className="form-group">
            <label htmlFor="email">Email</label>
            <input
              type="email"
              id="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              placeholder="nhap-email@example.com"
              disabled={loading}
            />
          </div>

          <div className="form-group">
            <label htmlFor="password">Mật khẩu</label>
            <input
              type="password"
              id="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              placeholder="••••••••"
              disabled={loading}
            />
          </div>

          <button type="submit" className="btn btn-primary btn-block" disabled={loading}>
            {loading ? 'Đang xác thực...' : 'Đăng Nhập'}
          </button>
        </form>

        <div className="login-footer-text">
          <p>Tài khoản dùng thử demo:</p>
          <code>admin@artify.com / admin123</code>
        </div>
      </div>
    </div>
  );
}
