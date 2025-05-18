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
    public class OrderStatusesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OrderStatusesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderStatus>>> Get() => await _context.OrderStatuses.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderStatus?>> GetOrderStatus(int id)
        {
            var status = await _context.OrderStatuses.FindAsync(id);
            if (status == null) return NotFound();
            return status;
        }

        [HttpPost]
        public async Task<ActionResult<OrderStatus>> Post(OrderStatus status)
        {
            _context.OrderStatuses.Add(status);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = status.StatusID }, status);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, OrderStatus status)
        {
            if (id != status.StatusID) return BadRequest();
            _context.Entry(status).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _context.OrderStatuses.FindAsync(id);
            if (status == null) return NotFound();
            _context.OrderStatuses.Remove(status);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
