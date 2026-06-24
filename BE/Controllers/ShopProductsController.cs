using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Artify_ecommerce.Data;
using Artify_ecommerce.Models;
using Artify_ecommerce.Helpers;

namespace Artify_ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ShopProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ShopProducts
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ShopProduct>>>> GetShopProducts()
        {
            var products = await _context.ShopProducts.ToListAsync();
            return Ok(new ApiResponse<IEnumerable<ShopProduct>>(products, "Lấy danh sách sản phẩm thành công"));
        }

        // GET: api/ShopProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ShopProduct>>> GetShopProduct(int id)
        {
            var shopProduct = await _context.ShopProducts.FindAsync(id);

            if (shopProduct == null)
            {
                return NotFound(new ApiResponse<ShopProduct>($"Không tìm thấy sản phẩm có ID = {id}"));
            }

            return Ok(new ApiResponse<ShopProduct>(shopProduct, "Lấy thông tin sản phẩm thành công"));
        }

        // POST: api/ShopProducts
        [HttpPost]
        public async Task<ActionResult<ApiResponse<ShopProduct>>> PostShopProduct(ShopProduct shopProduct)
        {
            _context.ShopProducts.Add(shopProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetShopProduct), 
                new { id = shopProduct.Id }, 
                new ApiResponse<ShopProduct>(shopProduct, "Tạo sản phẩm thành công")
            );
        }

        // PUT: api/ShopProducts/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<ShopProduct>>> PutShopProduct(int id, ShopProduct shopProduct)
        {
            if (id != shopProduct.Id)
            {
                return BadRequest(new ApiResponse<ShopProduct>("ID sản phẩm không trùng khớp"));
            }

            _context.Entry(shopProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopProductExists(id))
                {
                    return NotFound(new ApiResponse<ShopProduct>($"Không tìm thấy sản phẩm có ID = {id}"));
                }
                else
                {
                    throw;
                }
            }

            return Ok(new ApiResponse<ShopProduct>(shopProduct, "Cập nhật sản phẩm thành công"));
        }

        // DELETE: api/ShopProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteShopProduct(int id)
        {
            var shopProduct = await _context.ShopProducts.FindAsync(id);
            if (shopProduct == null)
            {
                return NotFound(new ApiResponse($"Không tìm thấy sản phẩm có ID = {id}"));
            }

            _context.ShopProducts.Remove(shopProduct);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse(null!, "Xóa sản phẩm thành công"));
        }

        private bool ShopProductExists(int id)
        {
            return _context.ShopProducts.Any(e => e.Id == id);
        }
    }
}
