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
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EmployeesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get() => await _context.Employees.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee?>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();
            return employee;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = employee.EmployeeID }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Employee employee)
        {
            if (id != employee.EmployeeID) return BadRequest();
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
