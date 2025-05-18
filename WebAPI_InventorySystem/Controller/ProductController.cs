using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_InventorySystem.Data;
using WebAPI_InventorySystem.Models;

namespace WebAPI_InventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductDto
                {
                    ProductID = p.ProductID,
                    Name = p.Name,
                    CategoryName = p.Category != null ? p.Category.CategoryName : null
                })
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.ProductID == id)
                .Select(p => new ProductDto
                {
                    ProductID = p.ProductID,
                    Name = p.Name,
                    CategoryName = p.Category != null ? p.Category.CategoryName : null
                })
                .FirstOrDefaultAsync();

            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProduct), new { id = product.ProductID }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Product product)
        {
            if (id != product.ProductID) return BadRequest();

            try
            {
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id)) return NotFound();
                throw;
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProductExists(int id) => _context.Products.Any(p => p.ProductID == id);
    }

    public class ProductDto
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? CategoryName { get; set; }
    }
}
