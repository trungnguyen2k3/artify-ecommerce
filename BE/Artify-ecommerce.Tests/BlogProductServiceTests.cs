using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using FluentAssertions;
using Artify_ecommerce.Data;
using Artify_ecommerce.Models;
using Artify_ecommerce.Services;
using Artify_ecommerce.Exceptions;

namespace Artify_ecommerce.Tests
{
    public class BlogProductServiceTests
    {
        // Hàm helper để khởi tạo DbContext In-Memory cho mỗi test case độc lập
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Đảm bảo mỗi test dùng 1 DB sạch
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task GetByIdAsync_WhenProductExists_ReturnsProductDto()
        {
            // Arrange (Thiết lập dữ liệu giả lập)
            using var context = GetInMemoryDbContext();
            
            var testProduct = new BlogProduct
            {
                Id = 1,
                Name = "Sản phẩm Blog Test",
                Description = "Mô tả sản phẩm blog test",
                Sku = "BLOG-TEST-001",
                CategoryId = 10,
                IsActive = true,
                Width = 120,
                Slug = "san-pham-blog-test",
                AuthorName = "Nguyen Van A"
            };
            
            context.BlogProducts.Add(testProduct);
            await context.SaveChangesAsync();

            var service = new BlogProductService(context);

            // Act (Thực thi hàm cần test)
            var result = await service.GetByIdAsync(1);

            // Assert (Kiểm tra kết quả sử dụng FluentAssertions)
            result.Should().NotBeNull();
            result.Id.Should().Be(testProduct.Id);
            result.Name.Should().Be(testProduct.Name);
            result.Description.Should().Be(testProduct.Description);
            result.Sku.Should().Be(testProduct.Sku);
            result.CategoryId.Should().Be(testProduct.CategoryId);
            result.IsActive.Should().Be(testProduct.IsActive);
            result.Width.Should().Be(testProduct.Width);
            result.Slug.Should().Be(testProduct.Slug);
            result.AuthorName.Should().Be(testProduct.AuthorName);
        }

        [Fact]
        public async Task GetByIdAsync_WhenProductDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange (Database trống rỗng)
            using var context = GetInMemoryDbContext();
            var service = new BlogProductService(context);

            // Act & Assert (Thực thi và kiểm chứng xem có ném đúng Exception không)
            Func<Task> act = async () => await service.GetByIdAsync(999);

            await act.Should().ThrowAsync<NotFoundException>()
                .WithMessage("Không tìm thấy sản phẩm Blog có ID = 999");
        }
    }
}
