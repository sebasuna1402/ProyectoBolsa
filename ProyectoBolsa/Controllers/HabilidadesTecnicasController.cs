using DataAccess.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoBolsa.Data;
using Services;

namespace ProyectoBolsa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabilidadesTecnicasController : ControllerBase
    {
        private readonly MyApiContext _context;

        public HabilidadesTecnicasController(MyApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabilidadesTecnicas>>> GetHabilidad()
        {
            if (_context.HabilidadesTecnicas == null)
            {
                return NotFound();
            }

            List<HabilidadesTecnicas> listaHabilidad = await _context.HabilidadesTecnicas.ToListAsync();

            return listaHabilidad;
        }

        [HttpPost]
        public async Task<ActionResult<HabilidadesTecnicas>> PostHabilidad(HabilidadesVm habilidadRequest)
        {
            if (_context.HabilidadesTecnicas == null)
            {
                return Problem("Entity set 'MyApiContext.Habilidad'  is null.");
            }

            HabilidadesTecnicas newHabilidad = new HabilidadesTecnicas();
            newHabilidad.Id = habilidadRequest.Id;
            newHabilidad.Nombre = habilidadRequest.Nombre;

            _context.HabilidadesTecnicas.Add(newHabilidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostHabilidad", new { id = newHabilidad.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHabilidad(int id, HabilidadesTecnicas habilidad)
        {
            if (id != habilidad.Id)
            {
                return BadRequest();
            }

            _context.Entry(habilidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabilidadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabilidad(int id)
        {
            if (_context.HabilidadesTecnicas == null)
            {
                return NotFound();
            }
            var habilidad = await _context.HabilidadesTecnicas.FindAsync(id);
            if (habilidad == null)
            {
                return NotFound();
            }

            _context.HabilidadesTecnicas.Remove(habilidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool HabilidadExists(int id)
        {
            return (_context.HabilidadesTecnicas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
