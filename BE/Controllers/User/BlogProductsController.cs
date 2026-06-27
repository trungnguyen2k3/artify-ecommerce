using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Artify_ecommerce.DTOs;
using Artify_ecommerce.Helpers;
using Artify_ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Artify_ecommerce.Controllers.User
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
        [HttpGet]
        public async Task<ActionResult<ApiResponse<object>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            if (page <= 0)  page = 1;
            if(pageSize <=0)  pageSize = 10;
            if(pageSize>50) pageSize = 50;
            var(items,totalCount) = await _blogProductService.GetAllAsync(page, pageSize);
            var responseData = new
            {
                Items = items,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize,
                TotalPages = (int)System.Math.Ceiling(totalCount / (double)pageSize)
            };
            return Ok(new ApiResponse<object>(responseData, "Lấy danh sách Blog Product thành công"));

        }
    }
}
