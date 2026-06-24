using System.Collections.Generic;

namespace Artify_ecommerce.Helpers
{
    /// <summary>
    /// Lớp bọc chuẩn cho dữ liệu trả về từ REST API (API Response Wrapper)
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu của payload trả về</typeparam>
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        public ApiResponse()
        {
        }

        // Tạo response thành công kèm data
        public ApiResponse(T data, string message = "Thao tác thành công")
        {
            Success = true;
            Message = message;
            Data = data;
            Errors = null;
        }

        // Tạo response thất bại kèm thông báo lỗi
        public ApiResponse(string message, List<string>? errors = null)
        {
            Success = false;
            Message = message;
            Data = default;
            Errors = errors;
        }
    }

    /// <summary>
    /// Phiên bản không generic của ApiResponse cho các trường hợp không trả về data
    /// </summary>
    public class ApiResponse : ApiResponse<object>
    {
        public ApiResponse() : base()
        {
        }

        public ApiResponse(object data, string message = "Thao tác thành công") : base(data, message)
        {
        }

        public ApiResponse(string message, List<string>? errors = null) : base(message, errors)
        {
        }
    }
}
