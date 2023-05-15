
using DataAccess.Entidades;
using Microsoft.EntityFrameworkCore;
using ProyectoBolsa.Data;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    internal class HabilidadCandidatoService : ICandidatoHabilidadService
    {
        private readonly MyApiContext _context;

        public HabilidadCandidatoService(MyApiContext context)
        {
            _context = context;
        }

        public async Task<List<HabilidadCandidatoVm>> GetAll()
        {
            List<HabilidadCandidato> listaCandidatoHabilidad = await _context.HabilidadCandidato.ToListAsync();

            List<HabilidadCandidatoVm> listaHabilidadVm = new List<HabilidadCandidatoVm>();

            foreach (HabilidadCandidato habilidadCandidato in listaCandidatoHabilidad)
            {
                HabilidadCandidatoVm newCandidatoHabilidadVm = new HabilidadCandidatoVm();
                newCandidatoHabilidadVm.HabilidadId = habilidadCandidato.HabilidadId;
                newCandidatoHabilidadVm.CandidatoId = habilidadCandidato.CandidatoId;
                listaHabilidadVm.Add(newCandidatoHabilidadVm);
            }

            return listaHabilidadVm;
        }

        public async Task<HabilidadCandidato> GetById(int id_candidato, int id_habilidad)
        {
            HabilidadCandidato newCandidatoHabilidad = new HabilidadCandidato();
            newCandidatoHabilidad = _context.HabilidadCandidato.SingleOrDefault(pc => pc.CandidatoId == id_candidato && pc.HabilidadId == id_habilidad);

            return newCandidatoHabilidad;
        }
        public async Task<HabilidadCandidato> Create(HabilidadCandidatoVm candidatohabilidadRequest)
        {
            HabilidadCandidato newCandidatoHabilidad = new HabilidadCandidato();
            newCandidatoHabilidad.CandidatoId = candidatohabilidadRequest.CandidatoId;
            newCandidatoHabilidad.HabilidadId = candidatohabilidadRequest.HabilidadId;

            //if (_context.CandidatoHabilidad == null)
            //{
            //   return Problem("Entity set 'MyApiContext.CandidatoHabilidad'  is null.");
            //}

            _context.HabilidadCandidato.Add(newCandidatoHabilidad);
            await _context.SaveChangesAsync();

            return newCandidatoHabilidad;
        }

        public async Task Delete(int id_candidato, int id_habilidad) 
        {
    
            HabilidadCandidato newCandidatoHabilidad = new HabilidadCandidato();
            newCandidatoHabilidad = _context.HabilidadCandidato.SingleOrDefault(pc => pc.CandidatoId == id_candidato && pc.HabilidadId == id_habilidad);

            _context.HabilidadCandidato.Remove(newCandidatoHabilidad);
            await _context.SaveChangesAsync();

        }



    }
}
