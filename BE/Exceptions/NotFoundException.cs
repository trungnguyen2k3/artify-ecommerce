using System;

namespace Artify_ecommerce.Exceptions
{
    /// <summary>
    /// Ngoại lệ ném ra khi không tìm thấy tài nguyên (HTTP 404)
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
