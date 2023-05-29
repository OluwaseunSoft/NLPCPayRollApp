using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLPCPayRollApp.Data;
using NLPCPayRollApp.Models;

namespace NLPCPayRollApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            try
            {
                return Ok(_context.Employees.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            try
            {

                var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
                if (employee == null)
                    return NotFound();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            try
            {
                var cadre = _context.CadreLevels.FirstOrDefault(e => e.Name == employee.CadreLevelName);
                if (cadre == null)
                    return BadRequest("Cadre Level Not Found");
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee updatedEmployee)
        {
            try
            {
                var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
                if (employee == null)
                    return NotFound();

                employee.Name = updatedEmployee.Name;
                employee.Designation = updatedEmployee.Designation;
                employee.CadreLevelName = updatedEmployee.CadreLevelName;
                _context.Employees.Update(employee);
                _context.SaveChanges();

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
                if (employee == null)
                    return NotFound();

                _context.Remove(employee);
                _context.SaveChanges();
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
