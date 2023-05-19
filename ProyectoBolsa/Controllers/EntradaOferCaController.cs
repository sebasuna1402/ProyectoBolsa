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
    public class EntradaOferCaController : Controller
    {

        private readonly IEntradaOferCaService _candidatoofertaService;

        public EntradaOferCaController(IEntradaOferCaService candidatoofertaService)
        {
            _candidatoofertaService = candidatoofertaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntradaOferCaVm>>> GetCandidatoOferta()
        {
            List<EntradaOferCaVm> listCandidatoofertaVm = await _candidatoofertaService.GetAll();

            if (listCandidatoofertaVm == null)
            {
                return NotFound();
            }

            return Ok(listCandidatoofertaVm);
        }

        [HttpPost]
        public async Task<ActionResult<EntradaOferCa>> PostCandidatoOferta(EntradaOferCaVm candidatoofertaRequest)
        {
            if (candidatoofertaRequest == null)
            {
                return BadRequest();
            }

            EntradaOferCa newCandidatoOferta = await _candidatoofertaService.Create(candidatoofertaRequest);

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
