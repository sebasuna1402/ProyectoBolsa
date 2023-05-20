using DataAccess.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoBolsa.Data;
using Services;
using Services.IServices;

namespace ProyectoBolsa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ab_EntradaCanHabController : Controller
    {
        private readonly IEntradaHabilidadCaService _candidatohabilidadService;

        public Ab_EntradaCanHabController(IEntradaHabilidadCaService candidatohabilidadService)
        {
            _candidatohabilidadService = candidatohabilidadService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntradaHabilidadCaVm>>> GetCandidatoHabilidad()
        {
            List<EntradaHabilidadCaVm> listCandidatoHabilidadVm = await _candidatohabilidadService.GetAll();

            if (listCandidatoHabilidadVm == null)
            {
                return NotFound();
            }

            return Ok(listCandidatoHabilidadVm);
        }

        [HttpPost]
        public async Task<ActionResult<EntradaHabilidadCa>> PostCandidatoHabilidad(EntradaHabilidadCaVm candidatohabilidadRequest)
        {
            if (candidatohabilidadRequest == null)
            {
                return BadRequest();
            }

            EntradaHabilidadCa newCandidatoHabilidad = await _candidatohabilidadService.Create(candidatohabilidadRequest);

            return CreatedAtAction("GetCandidatoHabilidad", new { id = newCandidatoHabilidad.CandidatoId }, newCandidatoHabilidad);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCandidatoHabilidad(int id_candidato, int id_habilidad)
        {
            var candidatohabilidad = await _candidatohabilidadService.GetById(id_candidato, id_habilidad);
            if (candidatohabilidad == null)
            {
                return NotFound();
            }

            await _candidatohabilidadService.Delete(id_candidato, id_habilidad);
            return NoContent();
        }
    }
}
