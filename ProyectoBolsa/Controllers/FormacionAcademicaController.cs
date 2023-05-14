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
    public class FormacionAcademicaController : ControllerBase
    {
        private readonly MyApiContext _context;

        public FormacionAcademicaController(MyApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<FormacionAcademica>> PostFormacion(FormacionAcademicaVm formacionRequest)
        {
            if (_context.FormacionAcademica == null)
            {
                return Problem("Entity set 'MyApiContext.Formacion'  is null.");
            }

            FormacionAcademica newFormacion = new FormacionAcademica();
            newFormacion.Id = formacionRequest.Id;
            newFormacion.CandidatoId = formacionRequest.CandidatoId;
            newFormacion.Formacion = formacionRequest.Formacion;
            newFormacion.Años_Estudio = formacionRequest.Años_Estudio;
            newFormacion.Fecha_Culminacion = formacionRequest.Fecha_Culminacion;


            _context.FormacionAcademica.Add(newFormacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostFormacion", new { id = newFormacion.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormacion(int id, FormacionAcademica formacion)
        {
            if (id != formacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(formacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormacionExists(id))
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
        public async Task<IActionResult> DeleteFormacion(int id)
        {
            if (_context.FormacionAcademica == null)
            {
                return NotFound();
            }
            var formacion = await _context.FormacionAcademica.FindAsync(id);
            if (formacion == null)
            {
                return NotFound();
            }

            _context.FormacionAcademica.Remove(formacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormacionExists(int id)
        {
            return (_context.FormacionAcademica?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
