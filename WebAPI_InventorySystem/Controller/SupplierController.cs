using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_InventorySystem.Data;
using WebAPI_InventorySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI_InventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SuppliersController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> Get() => await _context.Suppliers.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier?>> GetSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null) return NotFound();
            return supplier;
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> Post(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = supplier.SupplierID }, supplier);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Supplier supplier)
        {
            if (id != supplier.SupplierID) return BadRequest();
            _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null) return NotFound();
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
