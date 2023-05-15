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
    public class CandidatoHabilidadController : Controller
    {
        private readonly ICandidatoHabilidadService _candidatohabilidadService;

        public CandidatoHabilidadController(ICandidatoHabilidadService candidatohabilidadService)
        {
            _candidatohabilidadService = candidatohabilidadService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabilidadCandidatoVm>>> GetCandidatoHabilidad()
        {
            List<HabilidadCandidatoVm> listCandidatoHabilidadVm = await _candidatohabilidadService.GetAll();

            if (listCandidatoHabilidadVm == null)
            {
                return NotFound();
            }

            return Ok(listCandidatoHabilidadVm);
        }

        [HttpPost]
        public async Task<ActionResult<HabilidadCandidato>> PostCandidatoHabilidad(HabilidadCandidatoVm candidatohabilidadRequest)
        {
            if (candidatohabilidadRequest == null)
            {
                return BadRequest();
            }

            HabilidadCandidato newCandidatoHabilidad = await _candidatohabilidadService.Create(candidatohabilidadRequest);

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
