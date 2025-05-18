using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_InventorySystem.Data;
using WebAPI_InventorySystem.DTOs;
using WebAPI_InventorySystem.Models;

namespace WebAPI_InventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryMovementsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public InventoryMovementsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryMovementDto>>> Get()
        {
            var movements = await _context.InventoryMovements
                .Select(m => new InventoryMovementDto
                {
                    InventoryMovementID = m.InventoryMovementID,
                    ProductID = m.ProductID,
                    MovementTypeID = m.MovementTypeID,
                    QuantityChanged = m.QuantityChanged,
                    MovementDate = m.MovementDate
                })
                .ToListAsync();

            return movements;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryMovementDto>> Get(int id)
        {
            var movement = await _context.InventoryMovements
                .Where(m => m.InventoryMovementID == id)
                .Select(m => new InventoryMovementDto
                {
                    InventoryMovementID = m.InventoryMovementID,
                    ProductID = m.ProductID,
                    MovementTypeID = m.MovementTypeID,
                    QuantityChanged = m.QuantityChanged,
                    MovementDate = m.MovementDate
                })
                .FirstOrDefaultAsync();

            if (movement == null)
                return NotFound();

            return movement;
        }

        [HttpPost]
        public async Task<ActionResult<InventoryMovementDto>> Post(InventoryMovementDto dto)
        {
            var movement = new InventoryMovement
            {
                ProductID = dto.ProductID,
                MovementTypeID = dto.MovementTypeID,
                QuantityChanged = dto.QuantityChanged,
                MovementDate = dto.MovementDate
            };

            _context.InventoryMovements.Add(movement);
            await _context.SaveChangesAsync();

            dto.InventoryMovementID = movement.InventoryMovementID;

            return CreatedAtAction(nameof(Get), new { id = movement.InventoryMovementID }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, InventoryMovementDto dto)
        {
            if (id != dto.InventoryMovementID)
                return BadRequest();

            var movement = await _context.InventoryMovements.FindAsync(id);
            if (movement == null)
                return NotFound();

            movement.ProductID = dto.ProductID;
            movement.MovementTypeID = dto.MovementTypeID;
            movement.QuantityChanged = dto.QuantityChanged;
            movement.MovementDate = dto.MovementDate;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movement = await _context.InventoryMovements.FindAsync(id);
            if (movement == null)
                return NotFound();

            _context.InventoryMovements.Remove(movement);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
