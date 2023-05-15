using DataAccess.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoBolsa.Data;
using Services;
using Services.IServices;

namespace ProyectoBolsa.Controllers
{
    //guiarse con el ejemplo del prof

    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoOfertaController : Controller
    {

        private readonly ICandidatoOfertaService _candidatoofertaService;

        public CandidatoOfertaController(ICandidatoOfertaService candidatoofertaService)
        {
            _candidatoofertaService = candidatoofertaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfertaCandidatoVm>>> GetCandidatoOferta()
        {
            List<OfertaCandidatoVm> listCandidatoofertaVm = await _candidatoofertaService.GetAll();

            if (listCandidatoofertaVm == null)
            {
                return NotFound();
            }

            return Ok(listCandidatoofertaVm);
        }

        [HttpPost]
        public async Task<ActionResult<OfertaCandidato>> PostCandidatoOferta(OfertaCandidatoVm candidatoofertaRequest)
        {
            if (candidatoofertaRequest == null)
            {
                return BadRequest();
            }

            OfertaCandidato newCandidatoOferta = await _candidatoofertaService.Create(candidatoofertaRequest);

            return CreatedAtAction("GetCandidatoOferta", new { id = newCandidatoOferta.CandidatoId }, newCandidatoOferta);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCandidatoOferta(int id_candidato, int id_oferta)
        {
            var candidatooferta = await _candidatoofertaService.GetById(id_candidato, id_oferta);
            if (candidatooferta == null)
            {
                return NotFound();
            }

            await _candidatoofertaService.Delete(id_candidato, id_oferta);
            return NoContent();
        }


    }
}
