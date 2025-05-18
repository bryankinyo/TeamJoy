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
    public class MovementTypesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MovementTypesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovementType>>> Get() => await _context.MovementTypes.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<MovementType?>> GetMovementType(int id)
        {
            var movementType = await _context.MovementTypes.FindAsync(id);
            if (movementType == null) return NotFound();
            return movementType;
        }

        [HttpPost]
        public async Task<ActionResult<MovementType>> Post(MovementType movementType)
        {
            _context.MovementTypes.Add(movementType);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = movementType.MovementTypeID }, movementType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MovementType movementType)
        {
            if (id != movementType.MovementTypeID) return BadRequest();
            _context.Entry(movementType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movementType = await _context.MovementTypes.FindAsync(id);
            if (movementType == null) return NotFound();
            _context.MovementTypes.Remove(movementType);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
