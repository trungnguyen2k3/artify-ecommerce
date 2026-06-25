using System.Threading.Tasks;
using Artify_ecommerce.DTOs;

namespace Artify_ecommerce.Services.Interfaces
{
    /// <summary>
    /// Giao diện định nghĩa các nghiệp vụ xử lý của Blog Product
    /// </summary>
    public interface IBlogProductService
    {
        /// <summary>
        /// Lấy chi tiết Blog Product theo ID
        /// </summary>
        /// <param name="id">ID của Blog Product</param>
        /// <returns>BlogProductDto chứa thông tin sản phẩm</returns>
        Task<BlogProductDto> GetByIdAsync(int id);
    }
}
