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
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CustomersController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get() => await _context.Customers.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer?>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return NotFound();
            return customer;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = customer.CustomerID }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Customer customer)
        {
            if (id != customer.CustomerID) return BadRequest();
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return NotFound();
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
