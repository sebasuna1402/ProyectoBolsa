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
    public class OfertaHabilidadController : ControllerBase
    {
        private readonly MyApiContext _context;
        public OfertaHabilidadController(MyApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabilidadOferta>>> GetOfertaHabilidad()
        {
            if (_context.HabilidadOferta == null)
            {
                return NotFound();
            }

            List<HabilidadOferta> listaOfertaHabilidad = await _context.HabilidadOferta.ToListAsync();

            return listaOfertaHabilidad;
        }

        [HttpPost]
        public async Task<ActionResult<HabilidadOferta>> PostOfertaHabilidad(HabilidadOfertaVm ofertahabilidadRequest)
        {
            HabilidadOferta newOfertaHabilidad = new HabilidadOferta();
            newOfertaHabilidad.OfertaId = ofertahabilidadRequest.OfertaId;
            newOfertaHabilidad.HabilidadId = ofertahabilidadRequest.HabilidadId;

            if (_context.HabilidadOferta == null)
            {
                return Problem("Entity set 'MyApiContext.OfertaHabilidad'  is null.");
            }
            _context.HabilidadOferta.Add(newOfertaHabilidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfertaHabilidad", new { id = newOfertaHabilidad.OfertaId }, newOfertaHabilidad);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOfertaHabilidad(int id_oferta, int id_habilidad)
        {
            if (_context.HabilidadOferta == null)
            {
                return NotFound();
            }

            HabilidadOferta newOfertaHabilidad = new HabilidadOferta();
            newOfertaHabilidad = _context.HabilidadOferta.SingleOrDefault(pc => pc.OfertaId == id_oferta && pc.HabilidadId == id_habilidad);

            if (newOfertaHabilidad == null)
            {
                return NotFound();
            }

            _context.HabilidadOferta.Remove(newOfertaHabilidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
