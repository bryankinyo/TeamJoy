using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_InventorySystem.Data;
using WebAPI_InventorySystem.DTOs;
using WebAPI_InventorySystem.Models;

namespace WebAPI_InventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderDetailsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SalesOrderDetailsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesOrderDetailDto>>> Get()
        {
            var details = await _context.SalesOrderDetails
                .Select(d => new SalesOrderDetailDto
                {
                    SalesOrderDetailID = d.SalesOrderDetailID,
                    SalesOrderID = d.SalesOrderID,
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
        public async Task<ActionResult<SalesOrderDetailDto>> Get(int id)
        {
            var detail = await _context.SalesOrderDetails
                .Where(d => d.SalesOrderDetailID == id)
                .Select(d => new SalesOrderDetailDto
                {
                    SalesOrderDetailID = d.SalesOrderDetailID,
                    SalesOrderID = d.SalesOrderID,
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
        public async Task<ActionResult<SalesOrderDetailDto>> Post(SalesOrderDetailDto dto)
        {
            var detail = new SalesOrderDetail
            {
                SalesOrderID = dto.SalesOrderID,
                ProductID = dto.ProductID,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                SubTotal = dto.SubTotal,
                TotalPrice = dto.TotalPrice
            };

            _context.SalesOrderDetails.Add(detail);
            await _context.SaveChangesAsync();

            dto.SalesOrderDetailID = detail.SalesOrderDetailID;

            return CreatedAtAction(nameof(Get), new { id = detail.SalesOrderDetailID }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SalesOrderDetailDto dto)
        {
            if (id != dto.SalesOrderDetailID)
                return BadRequest();

            var detail = await _context.SalesOrderDetails.FindAsync(id);
            if (detail == null)
                return NotFound();

            detail.SalesOrderID = dto.SalesOrderID;
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
            var detail = await _context.SalesOrderDetails.FindAsync(id);
            if (detail == null)
                return NotFound();

            _context.SalesOrderDetails.Remove(detail);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
