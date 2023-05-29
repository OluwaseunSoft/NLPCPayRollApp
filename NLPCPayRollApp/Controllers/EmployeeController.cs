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

        [HttpGet("PaySlip")]
        public ActionResult<PaySlip> ViewPaySlip(int id)
        {
            try
            {
                var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
                if (employee == null)
                    return NotFound("Staff Details Not Found");
                var cadreLevel = _context.CadreLevels.Include(c => c.PayrollComponents).FirstOrDefault(c => c.Name == employee.CadreLevelName);
                if (cadreLevel == null)
                    return NotFound("Staff Details Not Found");
                var earning = cadreLevel.PayrollComponents.BasicSalary + cadreLevel.PayrollComponents.Housing + cadreLevel.PayrollComponents.Transport
                                + cadreLevel.PayrollComponents.Furniture + cadreLevel.PayrollComponents.Entertainment + cadreLevel.PayrollComponents.Lunch + cadreLevel.PayrollComponents.Passage
                                + cadreLevel.PayrollComponents.Dressing + cadreLevel.PayrollComponents.Bonus + cadreLevel.PayrollComponents.ThirteenthMonth + cadreLevel.PayrollComponents.Utility + cadreLevel.PayrollComponents.OtherAllowances;
                var deduction = cadreLevel.PayrollComponents.NHF + cadreLevel.PayrollComponents.NHIS + cadreLevel.PayrollComponents.NPS + cadreLevel.PayrollComponents.LifeAssurance + cadreLevel.PayrollComponents.TaxPayable;
                var payslip = new PaySlip
                {
                    EmployeeName = employee.Name,
                    CadreLevelName = cadreLevel.Name,
                    Earnings = earning,
                    Deductions = deduction,
                    NetSalary = Convert.ToDecimal(earning),//Convert.ToDecimal(cadreLevel.PayrollComponents.GrossIncome - deduction),
                    GrossIncome = earning + deduction//cadreLevel.PayrollComponents.GrossIncome
                };

                return Ok(payslip);
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
