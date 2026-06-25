import React from 'react';

export default function Footer() {
  return (
    <footer className="footer">
      <div className="footer-container">
        <p>&copy; {new Date().getFullYear()} Artify Ecommerce Gallery. All rights reserved.</p>
        <p className="footer-subtext">Xây dựng trên nền tảng ReactJS + .NET Core REST API</p>
      </div>
    </footer>
  );
}
