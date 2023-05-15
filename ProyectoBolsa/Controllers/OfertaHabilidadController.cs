﻿using DataAccess.Entidades;
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
    public class OfertaHabilidadController : Controller
    {
        private readonly IOfertaHabilidadService _candidatohabilidadService;

        public OfertaHabilidadController(IOfertaHabilidadService candidatohabilidadService)
        {
            _candidatohabilidadService = candidatohabilidadService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabilidadOfertaVm>>> GetOfertaHabilidad()
        {
            List<HabilidadOfertaVm> listOfertaHabilidadVm = await _candidatohabilidadService.GetAll();

            if (listOfertaHabilidadVm == null)
            {
                return NotFound();
            }

            return Ok(listOfertaHabilidadVm);
        }

        [HttpPost]
        public async Task<ActionResult<HabilidadOferta>> PostOfertaHabilidad(HabilidadOfertaVm ofertahabilidadRequest)
        {
            if (ofertahabilidadRequest == null)
            {
                return BadRequest();
            }

            HabilidadOferta newOfertaHabilidad = await _candidatohabilidadService.Create(ofertahabilidadRequest);

            return CreatedAtAction("GetOfertaHabilidad", new { id = newOfertaHabilidad.OfertaId }, newOfertaHabilidad);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOfertaHabilidad(int id_oferta, int id_habilidad)
        {
            var ofertahabilidad = await _candidatohabilidadService.GetById(id_oferta, id_habilidad);
            if (ofertahabilidad == null)
            {
                return NotFound();
            }

            await _candidatohabilidadService.Delete(id_oferta, id_habilidad);
            return NoContent();
        }

    }
}
