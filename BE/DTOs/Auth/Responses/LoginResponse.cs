namespace Artify_ecommerce.DTOs.Auth.Responses
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty; 
    }
}
