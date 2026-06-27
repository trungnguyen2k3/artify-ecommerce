using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Artify_ecommerce.Models;
using Artify_ecommerce.DTOs;
using Artify_ecommerce.Exceptions;
using Artify_ecommerce.Services.Interfaces;

namespace Artify_ecommerce.Services
{
    /// <summary>
    /// Lớp triển khai các nghiệp vụ của Blog Product
    /// </summary>
    public class BlogProductService : IBlogProductService
    {
        private readonly AppDbContext _context;

        public BlogProductService(AppDbContext context)
        {
            _context = context;
        }

      
        public async Task<BlogProductDto> GetByIdAsync(int id)
        {
            // 1. Truy vấn database lấy thông tin thực thể (Entity)
            var blogProduct = await _context.BlogProducts.FindAsync(id);

            // 2. Kiểm tra nếu không tồn tại thì ném ra Custom Exception (HTTP 404)
            // Lỗi này sẽ được bắt tự động bởi ExceptionHandlingMiddleware và trả về JSON chuẩn
            if (blogProduct == null)
            {
                throw new NotFoundException($"Không tìm thấy sản phẩm Blog có ID = {id}");
            }

            // 3. Mapping dữ liệu từ Entity sang DTO để trả về cho Client
            var dto = new BlogProductDto
            {
                Id = blogProduct.Id,
                Name = blogProduct.Name,
                Description = blogProduct.Description,
                Photo = blogProduct.Photo,
                CategoryId = blogProduct.CategoryId,
                IsActive = blogProduct.IsActive,
                Sku = blogProduct.Sku,
                Width = blogProduct.Width,
                Slug = blogProduct.Slug,
                AuthorName = blogProduct.AuthorName
            };

            return dto;
        }
        public async Task<(List<BlogProductDto>, int TotalCount)> GetAllAsync(int page, int pageSize)
        {
            var query = _context.BlogProducts.AsNoTracking();
            int totalCount = await query.CountAsync();
            int skipCount = (page - 1) * pageSize;
            var items = await query
                .Skip(skipCount)
                .Take(pageSize)
                .Select(blogProduct => new BlogProductDto
                {
                    Id = blogProduct.Id,
                    Name = blogProduct.Name,
                    Description = blogProduct.Description,
                    Photo = blogProduct.Photo,
                    CategoryId = blogProduct.CategoryId,
                    IsActive = blogProduct.IsActive,
                    Sku = blogProduct.Sku,
                    Width = blogProduct.Width,
                    Slug = blogProduct.Slug,
                    AuthorName = blogProduct.AuthorName
                })
                .ToListAsync();
            return (items, totalCount);
        }

    }
}
