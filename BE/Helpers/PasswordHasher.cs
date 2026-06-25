using BCrypt.Net;

namespace Artify_ecommerce.Helpers
{
    public static class PasswordHasher
    {
        // băm mật khẩu người thành mật khẩu mã hóa 
        // Ví dụ 123 => kdjaksdab#sjdakj
    public static String HashPassword(String password){
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
        // Xác thực mật khẩu đã mã hóa( từ db), và mật khẩu người dùng nhập vào(từ api login)
    public static bool VerifyPassword(String password, String hashpassword)
        {
            return BCrypt.Net.BCrypt.Verify(password,hashpassword);
        }
    }
}
