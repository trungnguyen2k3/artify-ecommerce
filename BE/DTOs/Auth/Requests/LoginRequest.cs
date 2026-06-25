using System.ComponentModel.DataAnnotations;

namespace Artify_ecommerce.DTOs.Auth.Requests
{
    public class LoginRequest
    {
        [Required(ErrorMessage ="Tên đăng nhập không được để trống")]
        public String Username { get; set; }
        [Required(ErrorMessage ="Mật khẩu không được để trống")]
        public String Password { get; set; }
    }
}
