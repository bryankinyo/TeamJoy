using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_InventorySystem.Data;
using WebAPI_InventorySystem.Models;

namespace WebAPI_InventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> Get()
        {
            return await _context.Payments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null) return NotFound();
            return Ok(payment);
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> Post(Payment payment)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPayment), new { id = payment.PaymentID }, payment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Payment payment)
        {
            if (id != payment.PaymentID) return BadRequest();

            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return NotFound();

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
