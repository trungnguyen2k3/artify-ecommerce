using System;

namespace Artify_ecommerce.Exceptions
{
    /// <summary>
    /// Ngoại lệ ném ra khi người dùng không có quyền truy cập tài nguyên (HTTP 403 Forbidden)
    /// </summary>
    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message) : base(message)
        {
        }
    }
}
