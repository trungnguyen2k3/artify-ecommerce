using System;

namespace Artify_ecommerce.Exceptions
{
    /// <summary>
    /// Ngoại lệ ném ra khi yêu cầu không hợp lệ (HTTP 400)
    /// </summary>
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
