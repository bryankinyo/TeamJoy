using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_InventorySystem.Data;
using WebAPI_InventorySystem.DTOs;
using WebAPI_InventorySystem.Models;

namespace WebAPI_InventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderDetailsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PurchaseOrderDetailsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrderDetailDto>>> Get()
        {
            var details = await _context.PurchaseOrderDetails
                .Select(d => new PurchaseOrderDetailDto
                {
                    PurchaseOrderDetailID = d.PurchaseOrderDetailID,
                    PurchaseOrderID = d.PurchaseOrderID,
                    ProductID = d.ProductID,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    SubTotal = d.SubTotal,
                    TotalPrice = d.TotalPrice
                })
                .ToListAsync();

            return details;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrderDetailDto>> Get(int id)
        {
            var detail = await _context.PurchaseOrderDetails
                .Where(d => d.PurchaseOrderDetailID == id)
                .Select(d => new PurchaseOrderDetailDto
                {
                    PurchaseOrderDetailID = d.PurchaseOrderDetailID,
                    PurchaseOrderID = d.PurchaseOrderID,
                    ProductID = d.ProductID,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    SubTotal = d.SubTotal,
                    TotalPrice = d.TotalPrice
                })
                .FirstOrDefaultAsync();

            if (detail == null)
                return NotFound();

            return detail;
        }

        [HttpPost]
        public async Task<ActionResult<PurchaseOrderDetailDto>> Post(PurchaseOrderDetailDto dto)
        {
            var detail = new PurchaseOrderDetail
            {
                PurchaseOrderID = dto.PurchaseOrderID,
                ProductID = dto.ProductID,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                SubTotal = dto.SubTotal,
                TotalPrice = dto.TotalPrice
            };

            _context.PurchaseOrderDetails.Add(detail);
            await _context.SaveChangesAsync();

            dto.PurchaseOrderDetailID = detail.PurchaseOrderDetailID;

            return CreatedAtAction(nameof(Get), new { id = detail.PurchaseOrderDetailID }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PurchaseOrderDetailDto dto)
        {
            if (id != dto.PurchaseOrderDetailID)
                return BadRequest();

            var detail = await _context.PurchaseOrderDetails.FindAsync(id);
            if (detail == null)
                return NotFound();

            detail.PurchaseOrderID = dto.PurchaseOrderID;
            detail.ProductID = dto.ProductID;
            detail.Quantity = dto.Quantity;
            detail.UnitPrice = dto.UnitPrice;
            detail.SubTotal = dto.SubTotal;
            detail.TotalPrice = dto.TotalPrice;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var detail = await _context.PurchaseOrderDetails.FindAsync(id);
            if (detail == null)
                return NotFound();

            _context.PurchaseOrderDetails.Remove(detail);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
