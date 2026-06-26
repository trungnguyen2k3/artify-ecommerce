using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Artify_ecommerce.DTOs;
using Artify_ecommerce.Helpers;
using Artify_ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Artify_ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles ="User")]
    public class BlogProductsController : ControllerBase
    {
        private readonly IBlogProductService _blogProductService;

        public BlogProductsController(IBlogProductService blogProductService)
        {
            _blogProductService = blogProductService;
        }

        /// <summary>
        /// API lấy chi tiết Blog Product theo ID
        /// </summary>
        /// <param name="id">ID của sản phẩm blog</param>
        /// <returns>ApiResponse chứa thông tin sản phẩm dưới dạng DTO</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<BlogProductDto>>> GetById(int id)
        {
            // Controller KHÔNG CẦN dùng try-catch ở đây!
            // Nếu Service ném ra NotFoundException (khi không tìm thấy ID), 
            // ExceptionHandlingMiddleware sẽ tự động bắt được và phản hồi HTTP 404 kèm JSON chuẩn.
            var result = await _blogProductService.GetByIdAsync(id);

            return Ok(new ApiResponse<BlogProductDto>(result, "Lấy thông tin sản phẩm Blog thành công"));
        }
    }
}
