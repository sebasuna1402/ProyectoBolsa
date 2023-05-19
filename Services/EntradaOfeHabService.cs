
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
    public class EntradaOfeHabService : IEntradaOfeHabService
    {
        private readonly MyApiContext _context;

        public EntradaOfeHabService(MyApiContext context)
        {
            _context = context;
        }

        public async Task<List<EntradaOfeHabVm>> GetAll()
        {

            List<EntradaOfeHab> listaOfertaHabilidad = await _context.HabilidadOferta.ToListAsync();

            List<EntradaOfeHabVm> listaOfertaHabilidadVm = new List<EntradaOfeHabVm>();

            foreach (EntradaOfeHab ofertaHabilidad in listaOfertaHabilidad)
            {
                EntradaOfeHabVm newOfertaHabilidadVm = new EntradaOfeHabVm();
                newOfertaHabilidadVm.OfertaId = ofertaHabilidad.OfertaId;
                newOfertaHabilidadVm.HabilidadId = ofertaHabilidad.HabilidadId;
                listaOfertaHabilidadVm.Add(newOfertaHabilidadVm);
            }

            return listaOfertaHabilidadVm;
        }

        public async Task<EntradaOfeHab> GetById(int id_oferta, int id_habilidad)
        {
            EntradaOfeHab newOfertaHabilidad = new EntradaOfeHab();
            newOfertaHabilidad = _context.HabilidadOferta.SingleOrDefault(pc => pc.OfertaId == id_oferta && pc.HabilidadId == id_habilidad);

            return newOfertaHabilidad;
        }

        public async Task<EntradaOfeHab> Create(EntradaOfeHabVm ofertahabilidadRequest)
        {
            EntradaOfeHab newOfertaHabilidad = new EntradaOfeHab();
            newOfertaHabilidad.OfertaId = ofertahabilidadRequest.OfertaId;
            newOfertaHabilidad.HabilidadId = ofertahabilidadRequest.HabilidadId;

       

            _context.HabilidadOferta.Add(newOfertaHabilidad);
            await _context.SaveChangesAsync();

            return newOfertaHabilidad;
        }


        public async Task Delete(int id_oferta, int id_habilidad)
        {        

            EntradaOfeHab newOfertaHabilidad = new EntradaOfeHab();
            newOfertaHabilidad = _context.HabilidadOferta.SingleOrDefault(pc => pc.OfertaId == id_oferta && pc.HabilidadId == id_habilidad);         

            _context.HabilidadOferta.Remove(newOfertaHabilidad);
            await _context.SaveChangesAsync();
        }

    }
}


