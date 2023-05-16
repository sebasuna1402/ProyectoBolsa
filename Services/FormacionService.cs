
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
    public class FormacionService : IFormacionService
    {
        private readonly MyApiContext _context;

        public FormacionService(MyApiContext context)
        {
            _context = context;
        }

        public async Task<FormacionAcademica> GetById(int id)
        {
            var formacion = await _context.FormacionAcademica.FindAsync(id);

            return formacion;
        }

        public async Task<FormacionAcademica> Create(FormacionAcademicaVm formacionRequest)
        {

            FormacionAcademica  newFormacion = new FormacionAcademica();
            newFormacion.Id = formacionRequest.Id;
            newFormacion.CandidatoId = formacionRequest.CandidatoId;
            newFormacion.Formacion = formacionRequest.Formacion;
            newFormacion.AñosEstudio = formacionRequest.AñosEstudio;
            newFormacion.FechaFinalizacion = formacionRequest.FechaFinalizacion;

            _context.FormacionAcademica.Add(newFormacion);
            await _context.SaveChangesAsync();

            return newFormacion;
        }

        public async Task Update(int id, FormacionAcademicaVm formacionRequest)
        {
            FormacionAcademica FormacionEdit = await _context.FormacionAcademica.FindAsync(id);

            FormacionEdit.Formacion = formacionRequest.Formacion;
            FormacionEdit.AñosEstudio = formacionRequest.AñosEstudio;
            FormacionEdit.FechaFinalizacion = formacionRequest.FechaFinalizacion;

            _context.Entry(FormacionEdit).State = EntityState.Modified;

            await _context.SaveChangesAsync();
      
        }

        public async Task Delete(int id)
        {

            var formacion = await _context.FormacionAcademica.FindAsync(id);

            _context.FormacionAcademica.Remove(formacion);
            await _context.SaveChangesAsync();
        }

    }
}
//revsiar 