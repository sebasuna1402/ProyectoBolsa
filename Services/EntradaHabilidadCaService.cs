
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
    internal class EntradaHabilidadCaService : IEntradaHabilidadCaService
    {
        private readonly MyApiContext _context;

        public EntradaHabilidadCaService(MyApiContext context)
        {
            _context = context;
        }

        public async Task<List<EntradaHabilidadCaVm>> GetAll()
        {
            List<EntradaHabilidadCa> listaCandidatoHabilidad = await _context.EntradaHabilidadCa.ToListAsync();

            List<EntradaHabilidadCaVm> listaHabilidadVm = new List<EntradaHabilidadCaVm>();

            foreach (EntradaHabilidadCa habilidadCandidato in listaCandidatoHabilidad)
            {
                EntradaHabilidadCaVm newCandidatoHabilidadVm = new EntradaHabilidadCaVm();
                newCandidatoHabilidadVm.HabilidadId = habilidadCandidato.HabilidadId;
                newCandidatoHabilidadVm.CandidatoId = habilidadCandidato.CandidatoId;
                listaHabilidadVm.Add(newCandidatoHabilidadVm);
            }

            return listaHabilidadVm;
        }

        public async Task<EntradaHabilidadCa> GetById(int id_candidato, int id_habilidad)
        {
            EntradaHabilidadCa newCandidatoHabilidad = new EntradaHabilidadCa();
            newCandidatoHabilidad = _context.EntradaHabilidadCa.SingleOrDefault(pc => pc.CandidatoId == id_candidato && pc.HabilidadId == id_habilidad);

            return newCandidatoHabilidad;
        }
        public async Task<EntradaHabilidadCa> Create(EntradaHabilidadCaVm candidatohabilidadRequest)
        {
            EntradaHabilidadCa newCandidatoHabilidad = new EntradaHabilidadCa();
            newCandidatoHabilidad.CandidatoId = candidatohabilidadRequest.CandidatoId;
            newCandidatoHabilidad.HabilidadId = candidatohabilidadRequest.HabilidadId;

            //if (_context.CandidatoHabilidad == null)
            //{
            //   return Problem("Entity set 'MyApiContext.CandidatoHabilidad'  is null.");
            //}

            _context.EntradaHabilidadCa.Add(newCandidatoHabilidad);
            await _context.SaveChangesAsync();

            return newCandidatoHabilidad;
        }

        public async Task Delete(int id_candidato, int id_habilidad) 
        {
    
            EntradaHabilidadCa newCandidatoHabilidad = new EntradaHabilidadCa();
            newCandidatoHabilidad = _context.EntradaHabilidadCa.SingleOrDefault(pc => pc.CandidatoId == id_candidato && pc.HabilidadId == id_habilidad);

            _context.EntradaHabilidadCa.Remove(newCandidatoHabilidad);
            await _context.SaveChangesAsync();

        }



    }
}
