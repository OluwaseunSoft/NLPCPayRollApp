using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLPCPayRollApp.Data;
using NLPCPayRollApp.Models;

namespace NLPCPayRollApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadreLevelController : ControllerBase
    {
        private readonly DataContext _context;

        public CadreLevelController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CadreLevel>> GetCadreLevels()
        {
            try
            {
                return Ok(_context.CadreLevels.Include(c => c.PayrollComponents).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public ActionResult<CadreLevel> GetCadreLevel(int id)
        {
            try
            {
                var cadreLevel = _context.CadreLevels.Include(c => c.PayrollComponents).FirstOrDefault(c => c.Id == id);
                if (cadreLevel == null)
                    return NotFound();

                return Ok(cadreLevel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<CadreLevel> AddCadreLevel(CadreLevel cadreLevel)
        {
            try
            {
                cadreLevel.PayrollComponents.CadreLevelId = cadreLevel.Id;
                _context.CadreLevels.Add(cadreLevel);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetCadreLevel), new { id = cadreLevel.Id }, cadreLevel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCadreLevel(int id, CadreLevel updatedCadreLevel)
        {
            try
            {
                var cadreLevel = _context.CadreLevels.FirstOrDefault(c => c.Id == id);
                if (cadreLevel == null)
                    return NotFound();

                cadreLevel.Name = updatedCadreLevel.Name;
                cadreLevel.PayrollComponents = updatedCadreLevel.PayrollComponents;
                _context.CadreLevels.Update(cadreLevel);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCadreLevel(int id)
        {
            try
            {
                var cadreLevel = _context.CadreLevels.FirstOrDefault(c => c.Id == id);
                var payroll = _context.PayrollComponents.FirstOrDefault(c => c.CadreLevelId == id);
                if (cadreLevel == null || payroll == null)
                    return NotFound();

                _context.CadreLevels.Remove(cadreLevel);
                _context.PayrollComponents.Remove(payroll);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
