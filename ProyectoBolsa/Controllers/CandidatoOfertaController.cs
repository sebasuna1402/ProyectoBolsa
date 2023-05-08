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
    public class CandidatoOfertaController : ControllerBase
    {
        private readonly MyApiContext _context;
        public CandidatoOfertaController(MyApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfertaCandidato>>> GetCandidatoOferta()
        {
            if (_context.OfertaCandidato == null)
            {
                return NotFound();
            }

            List<OfertaCandidato> listaCandidatoOferta = await _context.OfertaCandidato.ToListAsync();

            return listaCandidatoOferta;
        }

        [HttpPost]
        public async Task<ActionResult<OfertaCandidato>> PostCandidatoOferta(CandidatoOfertaVm candidatoofertaRequest)
        {
            OfertaCandidato newCandidatoOferta = new OfertaCandidato();
            newCandidatoOferta.CandidatoId = candidatoofertaRequest.CandidatoId;
            newCandidatoOferta.OfertaId = candidatoofertaRequest.OfertaId;

            if (_context.OfertaCandidato == null)
            {
                return Problem("Entity set 'MyApiContext.CandidatoOferta'  is null.");
            }
            _context.OfertaCandidato.Add(newCandidatoOferta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidatoOferta", new { id = newCandidatoOferta.CandidatoId }, newCandidatoOferta);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCandidatoOferta(int id_candidato, int id_oferta)
        {
            if (_context.OfertaCandidato == null)
            {
                return NotFound();
            }

            OfertaCandidato newCandidatoOferta = new OfertaCandidato();
            newCandidatoOferta = _context.OfertaCandidato.SingleOrDefault(pc => pc.CandidatoId == id_candidato && pc.OfertaId == id_oferta);

            if (newCandidatoOferta == null)
            {
                return NotFound();
            }

            _context.OfertaCandidato.Remove(newCandidatoOferta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
