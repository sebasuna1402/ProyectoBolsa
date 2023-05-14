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
    public class CandidatoHabilidadesController : ControllerBase
    {
        private readonly MyApiContext _context;
        public CandidatoHabilidadesController(MyApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabilidadCandidato>>> GetCandidatoHabilidad()
        {
            if (_context.HabilidadCandidato == null)
            {
                return NotFound();
            }

            List<HabilidadCandidato> listaCandidatoHabilidad = await _context.HabilidadCandidato.ToListAsync();

            return listaCandidatoHabilidad;
        }

        [HttpPost]
        public async Task<ActionResult<HabilidadCandidato>> PostCandidatoHabilidad(HabilidadCandidatoVm candidatohabilidadRequest)
        {
            HabilidadCandidato newCandidatoHabilidad = new HabilidadCandidato();
            newCandidatoHabilidad.CandidatoId = candidatohabilidadRequest.CandidatoId;
            newCandidatoHabilidad.HabilidadId = candidatohabilidadRequest.HabilidadId;

            if (_context.HabilidadCandidato == null)
            {
                return Problem("Entity set 'MyApiContext.CandidatoHabilidad'  is null.");
            }
            _context.HabilidadCandidato.Add(newCandidatoHabilidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidatoHabilidad", new { id = newCandidatoHabilidad.CandidatoId }, newCandidatoHabilidad);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCandidatoHabilidad(int id_candidato, int id_habilidad)
        {
            if (_context.HabilidadCandidato == null)
            {
                return NotFound();
            }

            HabilidadCandidato newCandidatoHabilidad = new HabilidadCandidato();
            newCandidatoHabilidad = _context.HabilidadCandidato.SingleOrDefault(pc => pc.CandidatoId == id_candidato && pc.HabilidadId == id_habilidad);

            if (newCandidatoHabilidad == null)
            {
                return NotFound();
            }

            _context.HabilidadCandidato.Remove(newCandidatoHabilidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
