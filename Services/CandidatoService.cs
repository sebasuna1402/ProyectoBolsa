
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
    public class CandidatoService : ICandidatoService
    {
        private readonly MyApiContext _context;

        public CandidatoService(MyApiContext context)
        {
            _context = context;
        }

        public async Task<List<Candidato>> GetAll()
        {
            List<Candidato> listaCandidatos = await _context.Candidato
            .Include(c => c.FormacionAcademicas)
            .Select(c => new Candidato
            {
                Id = c.Id,
                Nombre = c.Nombre,
                PrimerApellido = c.PrimerApellido,
                SegundoApellido = c.SegundoApellido,
                Direccion = c.Direccion,
                Telefono = c.Telefono,
                ResumenPersonal = c.ResumenPersonal,
                HabilidadCandidatos = c.HabilidadCandidatos,
                OfertaCandidatos = c.OfertaCandidatos,


                FormacionAcademicas = c.FormacionAcademicas.Select(f => new FormacionAcademica
                {
                    Formacion = f.Formacion,
                    AñosEstudio = f.AñosEstudio,
                    FechaFinalizacion = f.FechaFinalizacion

                }).ToList(),
            })
                   .ToListAsync();



            return listaCandidatos;
        }

        public async Task<Candidato> GetById(int id)
        {
            var candidato = await _context.Candidato
           .Include(c => c.FormacionAcademicas).Include(c => c.HabilidadCandidatos).Include(c => c.OfertaCandidatos)
           .FirstOrDefaultAsync(c => c.Id == id);

            return candidato;
        }

        public async Task<Candidato> Create(CandidatoVm candidatoRequest)
        {
            Candidato newCandidato = new Candidato();
            newCandidato.Id = candidatoRequest.Id; 
            newCandidato.Nombre = candidatoRequest.Nombre;
            newCandidato.PrimerApellido = candidatoRequest.PrimerApellido;
            newCandidato.SegundoApellido = candidatoRequest.SegundoApellido;
            newCandidato.Direccion = candidatoRequest.Direccion;
            newCandidato.Telefono = candidatoRequest.Telefono;
            newCandidato.ResumenPersonal = candidatoRequest.ResumenPersonal;

         

            _context.Candidato.Add(newCandidato);
            await _context.SaveChangesAsync();

            return newCandidato;

        }

        public async Task Update(int id, CandidatoVm candidatoRequest)
        {
            Candidato CandidatoEdit = await _context.Candidato.FindAsync(id);

            CandidatoEdit.Nombre = candidatoRequest.Nombre;
            CandidatoEdit.PrimerApellido = candidatoRequest.PrimerApellido;
            CandidatoEdit.SegundoApellido = candidatoRequest.SegundoApellido;
            CandidatoEdit.Direccion = candidatoRequest.Direccion;
            CandidatoEdit.Telefono = candidatoRequest.Telefono;
            CandidatoEdit.ResumenPersonal = candidatoRequest.ResumenPersonal;

            _context.Entry(CandidatoEdit).State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var candidato = await _context.Candidato.FindAsync(id);

            _context.Candidato.Remove(candidato);
            await _context.SaveChangesAsync();
        }

    }
}
