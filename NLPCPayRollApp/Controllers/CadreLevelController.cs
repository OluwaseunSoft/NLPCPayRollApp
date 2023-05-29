using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLPCPayRollApp.Data;
using NLPCPayRollApp.Models;

namespace NLPCPayRollApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadreLevelController : ControllerBase
    {
        private readonly DataContext _context;
        private List<CadreLevel> cadreLevels;

        public CadreLevelController(DataContext context)
        {
            _context = context;
            cadreLevels = new List<CadreLevel>();
        }

        [HttpGet]
        public ActionResult<IEnumerable<CadreLevel>> GetCadreLevels()
        {
            try
            {
                return Ok(_context.CadreLevels.ToList());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public ActionResult<CadreLevel> GetCadreLevel(int id)
        {
            try
            {
                var cadreLevel = _context.CadreLevels.FirstOrDefault(c => c.Id == id);
                if (cadreLevel == null)
                    return NotFound();

                return Ok(cadreLevel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpPost]
        public ActionResult<CadreLevel> AddCadreLevel(CadreLevel cadreLevel)
        {
            try
            { 
            _context.CadreLevels.Add(cadreLevel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCadreLevel), new { id = cadreLevel.Id }, cadreLevel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCadreLevel(int id, CadreLevel updatedCadreLevel)
        {
            try { 
            var cadreLevel = _context.CadreLevels.FirstOrDefault(c => c.Id == id);
            if (cadreLevel == null)
                return NotFound();

            cadreLevel.Name = updatedCadreLevel.Name;
            _context.CadreLevels.Update(cadreLevel);
            _context.SaveChanges();

            return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCadreLevel(int id)
        {
            try { 
            var cadreLevel = _context.CadreLevels.FirstOrDefault(c => c.Id == id);
            if (cadreLevel == null)
                return NotFound();

            _context.CadreLevels.Remove(cadreLevel);
            _context.SaveChanges();
            return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }
    }
}
