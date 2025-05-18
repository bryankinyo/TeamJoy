using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_InventorySystem.Data;
using WebAPI_InventorySystem.DTOs;
using WebAPI_InventorySystem.Models;

namespace WebAPI_InventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PurchaseOrdersController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrderDto>>> Get()
        {
            var purchaseOrders = await _context.PurchaseOrders
                .Select(po => new PurchaseOrderDto
                {
                    PurchaseOrderID = po.PurchaseOrderID,
                    SupplierID = po.SupplierID,
                    EmployeeID = po.EmployeeID,
                    StatusID = po.StatusID,
                    OrderDate = po.OrderDate,
                    TotalAmount = po.TotalAmount
                })
                .ToListAsync();

            return purchaseOrders;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrderDto>> Get(int id)
        {
            var po = await _context.PurchaseOrders
                .Where(po => po.PurchaseOrderID == id)
                .Select(po => new PurchaseOrderDto
                {
                    PurchaseOrderID = po.PurchaseOrderID,
                    SupplierID = po.SupplierID,
                    EmployeeID = po.EmployeeID,
                    StatusID = po.StatusID,
                    OrderDate = po.OrderDate,
                    TotalAmount = po.TotalAmount
                })
                .FirstOrDefaultAsync();

            if (po == null)
                return NotFound();

            return po;
        }

        [HttpPost]
        public async Task<ActionResult<PurchaseOrderDto>> Post(PurchaseOrderDto dto)
        {
            var po = new PurchaseOrder
            {
                SupplierID = dto.SupplierID,
                EmployeeID = dto.EmployeeID,
                StatusID = dto.StatusID,
                OrderDate = dto.OrderDate,
                TotalAmount = dto.TotalAmount
            };

            _context.PurchaseOrders.Add(po);
            await _context.SaveChangesAsync();

            dto.PurchaseOrderID = po.PurchaseOrderID;

            return CreatedAtAction(nameof(Get), new { id = po.PurchaseOrderID }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PurchaseOrderDto dto)
        {
            if (id != dto.PurchaseOrderID)
                return BadRequest();

            var po = await _context.PurchaseOrders.FindAsync(id);
            if (po == null)
                return NotFound();

            po.SupplierID = dto.SupplierID;
            po.EmployeeID = dto.EmployeeID;
            po.StatusID = dto.StatusID;
            po.OrderDate = dto.OrderDate;
            po.TotalAmount = dto.TotalAmount;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var po = await _context.PurchaseOrders.FindAsync(id);
            if (po == null)
                return NotFound();

            _context.PurchaseOrders.Remove(po);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
