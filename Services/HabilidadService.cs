
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
    public class HabilidadService : IHabilidadService
    {
        private readonly MyApiContext _context;

        public HabilidadService(MyApiContext context)
        {
            _context = context;
        }

        public async Task<List<HabilidadesTecnicasVm>> GetAll()
        {

            List<HabilidadesTecnicas> listaHabilidad = await _context.HabilidadesTecnicas.ToListAsync();

            List<HabilidadesTecnicasVm> listaHabilidadVm = new List<HabilidadesTecnicasVm>();

            foreach (HabilidadesTecnicas habilidad in listaHabilidad)
            {
                HabilidadesTecnicasVm newHabilidadVm = new HabilidadesTecnicasVm();
                newHabilidadVm.Id = habilidad.Id;
                newHabilidadVm.Nombre = habilidad.Nombre;
                listaHabilidadVm.Add(newHabilidadVm);
            }

            return listaHabilidadVm;
        }

        public async Task<HabilidadesTecnicas> GetById(int id)
        {
            var habilidad = await _context.HabilidadesTecnicas.FindAsync(id);

            return habilidad;
        }

        public async Task<HabilidadesTecnicas> Create(HabilidadesTecnicasVm habilidadRequest)
        {

            HabilidadesTecnicas newHabilidad = new HabilidadesTecnicas();
            newHabilidad.Id = habilidadRequest.Id;
            newHabilidad.Nombre = habilidadRequest.Nombre;

            _context.HabilidadesTecnicas.Add(newHabilidad);
            await _context.SaveChangesAsync();

            return newHabilidad;
        }

        public async Task Update(int id, HabilidadesTecnicasVm habilidadRequest)
        {
            HabilidadesTecnicas HabilidadEdit = await _context.HabilidadesTecnicas.FindAsync(id);

            HabilidadEdit.Nombre = habilidadRequest.Nombre;

            _context.Entry(HabilidadEdit).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {

            var habilidad = await _context.HabilidadesTecnicas.FindAsync(id);

            _context.HabilidadesTecnicas.Remove(habilidad);
            await _context.SaveChangesAsync();
        }


    }
}
