using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_InventorySystem.Data;
using WebAPI_InventorySystem.DTOs;
using WebAPI_InventorySystem.Models;

namespace WebAPI_InventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrdersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SalesOrdersController(AppDbContext context) => _context = context;

        // GET: api/SalesOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesOrderDto>>> Get()
        {
            var salesOrders = await _context.SalesOrders
                .Select(s => new SalesOrderDto
                {
                    SalesOrderID = s.SalesOrderID,
                    CustomerID = s.CustomerID,
                    EmployeeID = s.EmployeeID,
                    StatusID = s.StatusID,
                    OrderDate = s.OrderDate,
                    TotalAmount = s.TotalAmount
                })
                .ToListAsync();

            return salesOrders;
        }

        // GET: api/SalesOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesOrderDto>> GetSalesOrder(int id)
        {
            var salesOrder = await _context.SalesOrders
                .Where(s => s.SalesOrderID == id)
                .Select(s => new SalesOrderDto
                {
                    SalesOrderID = s.SalesOrderID,
                    CustomerID = s.CustomerID,
                    EmployeeID = s.EmployeeID,
                    StatusID = s.StatusID,
                    OrderDate = s.OrderDate,
                    TotalAmount = s.TotalAmount
                })
                .FirstOrDefaultAsync();

            if (salesOrder == null)
                return NotFound();

            return salesOrder;
        }

        // POST: api/SalesOrders
        [HttpPost]
        public async Task<ActionResult<SalesOrderDto>> Post(SalesOrderDto dto)
        {
            var salesOrder = new SalesOrder
            {
                CustomerID = dto.CustomerID,
                EmployeeID = dto.EmployeeID,
                StatusID = dto.StatusID,
                OrderDate = dto.OrderDate,
                TotalAmount = dto.TotalAmount
            };

            _context.SalesOrders.Add(salesOrder);
            await _context.SaveChangesAsync();

            dto.SalesOrderID = salesOrder.SalesOrderID;

            return CreatedAtAction(nameof(Get), new { id = salesOrder.SalesOrderID }, dto);
        }

        // PUT: api/SalesOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SalesOrderDto dto)
        {
            if (id != dto.SalesOrderID)
                return BadRequest();

            var salesOrder = await _context.SalesOrders.FindAsync(id);
            if (salesOrder == null)
                return NotFound();

            salesOrder.CustomerID = dto.CustomerID;
            salesOrder.EmployeeID = dto.EmployeeID;
            salesOrder.StatusID = dto.StatusID;
            salesOrder.OrderDate = dto.OrderDate;
            salesOrder.TotalAmount = dto.TotalAmount;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/SalesOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var salesOrder = await _context.SalesOrders.FindAsync(id);
            if (salesOrder == null)
                return NotFound();

            _context.SalesOrders.Remove(salesOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
