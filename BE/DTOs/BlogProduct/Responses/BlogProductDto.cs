namespace Artify_ecommerce.DTOs
{
    /// <summary>
    /// Đối tượng truyền dữ liệu (DTO) của Blog Product
    /// Dùng để định nghĩa cấu trúc dữ liệu trả về cho Client, ẩn đi các thông tin nhạy cảm hoặc không cần thiết
    /// </summary>
    public class BlogProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public string Sku { get; set; } = string.Empty;
        public int? Width { get; set; }
        public string? Slug { get; set; }
        public string? AuthorName { get; set; }
        
    }
}
    