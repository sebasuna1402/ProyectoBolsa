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

    public class HabilidadesTecnicasController : ControllerBase
    {

        private readonly IHabilidadService _habilidadService;

        public HabilidadesTecnicasController(IHabilidadService habilidadService)
        {
            _habilidadService = habilidadService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabilidadesTecnicasVm>>> GetHabilidad()
        {
            List<HabilidadesTecnicasVm> listHabilidad = await _habilidadService.GetAll();

            if (listHabilidad == null)
            {
                return NotFound();
            }

            return Ok(listHabilidad);
        }

        [HttpPost]
        public async Task<ActionResult<HabilidadesTecnicas>> PostHabilidad(HabilidadesTecnicasVm habilidadRequest)
        {
            if (habilidadRequest == null)
            {
                return BadRequest();
            }

            HabilidadesTecnicas newHabilidad = await _habilidadService.Create(habilidadRequest);

            return CreatedAtAction("GetHabilidad", new { id = newHabilidad.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHabilidad(int id, HabilidadesTecnicasVm habilidadRequest)
        {
            if (habilidadRequest == null)
            {
                return BadRequest();
            }

            var habilidad = await _habilidadService.GetById(id);

            if (habilidad == null)
            {
                return NotFound();
            }

            await _habilidadService.Update(id, habilidadRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabilidad(int id)
        {
            var habilidad = await _habilidadService.GetById(id);
            if (habilidad == null)
            {
                return NotFound();
            }

            await _habilidadService.Delete(id);
            return NoContent();
        }

    }
}
