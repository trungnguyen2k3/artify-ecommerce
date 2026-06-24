using System;

namespace Artify_ecommerce.Exceptions
{
    /// <summary>
    /// Ngoại lệ ném ra khi người dùng chưa xác thực hoặc token không hợp lệ (HTTP 401 Unauthorized)
    /// </summary>
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message)
        {
        }
    }
}
