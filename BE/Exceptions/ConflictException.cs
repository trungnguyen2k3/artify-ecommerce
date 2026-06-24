using System;

namespace Artify_ecommerce.Exceptions
{
    /// <summary>
    /// Ngoại lệ ném ra khi xảy ra xung đột dữ liệu (HTTP 409 Conflict)
    /// </summary>
    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message)
        {
        }
    }
}
