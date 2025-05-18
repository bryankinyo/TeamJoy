using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_InventorySystem.Data;
using WebAPI_InventorySystem.Models;

namespace WebAPI_InventorySystem.Controller

{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get() => await _context.Categories.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Category?>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();  // HTTP 404 Not Found
            }

            return category;  // non-nullable
        }


        [HttpPost]
        public async Task<ActionResult<Category>> Post(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = category.CategoryID }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Category category)
        {
            if (id != category.CategoryID) return BadRequest();
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

