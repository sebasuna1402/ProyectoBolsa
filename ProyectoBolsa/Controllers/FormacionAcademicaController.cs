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
    public class FormacionAcademicaController : ControllerBase
    {
        private readonly IFormacionService _formacionService;

        public FormacionAcademicaController(IFormacionService formacionServiceService)
        {
            _formacionService = formacionServiceService;
        }

        [HttpPost]
        public async Task<ActionResult<FormacionAcademica>> PostFormacion(FormacionAcademicaVm formacionRequest)
        {
            if (formacionRequest == null)
            {
                return BadRequest();
            }

            FormacionAcademica newFormacion = await _formacionService.Create(formacionRequest);

            return CreatedAtAction("PostFormacion", new { id = newFormacion.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormacion(int id, FormacionAcademicaVm formacionRequest)
        {
            if (formacionRequest == null)
            {
                return BadRequest();
            }

            var formacion = await _formacionService.GetById(id);

            if (formacion == null)
            {
                return NotFound();
            }

            await _formacionService.Update(id, formacionRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormacion(int id)
        {
            var formacion = await _formacionService.GetById(id);
            if (formacion == null)
            {
                return NotFound();
            }

            await _formacionService.Delete(id);
            return NoContent();
        }

    }
}
