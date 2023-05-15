
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
    public class OfertaHabilidadService : IOfertaHabilidadService
    {
        private readonly MyApiContext _context;

        public OfertaHabilidadService(MyApiContext context)
        {
            _context = context;
        }

        public async Task<List<HabilidadOfertaVm>> GetAll()
        {

            List<HabilidadOferta> listaOfertaHabilidad = await _context.HabilidadOferta.ToListAsync();

            List<HabilidadOfertaVm> listaOfertaHabilidadVm = new List<HabilidadOfertaVm>();

            foreach (HabilidadOferta ofertaHabilidad in listaOfertaHabilidad)
            {
                HabilidadOfertaVm newOfertaHabilidadVm = new HabilidadOfertaVm();
                newOfertaHabilidadVm.OfertaId = ofertaHabilidad.OfertaId;
                newOfertaHabilidadVm.HabilidadId = ofertaHabilidad.HabilidadId;
                listaOfertaHabilidadVm.Add(newOfertaHabilidadVm);
            }

            return listaOfertaHabilidadVm;
        }

        public async Task<HabilidadOferta> GetById(int id_oferta, int id_habilidad)
        {
            HabilidadOferta newOfertaHabilidad = new HabilidadOferta();
            newOfertaHabilidad = _context.HabilidadOferta.SingleOrDefault(pc => pc.OfertaId == id_oferta && pc.HabilidadId == id_habilidad);

            return newOfertaHabilidad;
        }

        public async Task<HabilidadOferta> Create(HabilidadOfertaVm ofertahabilidadRequest)
        {
            HabilidadOferta newOfertaHabilidad = new HabilidadOferta();
            newOfertaHabilidad.OfertaId = ofertahabilidadRequest.OfertaId;
            newOfertaHabilidad.HabilidadId = ofertahabilidadRequest.HabilidadId;

       

            _context.HabilidadOferta.Add(newOfertaHabilidad);
            await _context.SaveChangesAsync();

            return newOfertaHabilidad;
        }


        public async Task Delete(int id_oferta, int id_habilidad)
        {        

            HabilidadOferta newOfertaHabilidad = new HabilidadOferta();
            newOfertaHabilidad = _context.HabilidadOferta.SingleOrDefault(pc => pc.OfertaId == id_oferta && pc.HabilidadId == id_habilidad);         

            _context.HabilidadOferta.Remove(newOfertaHabilidad);
            await _context.SaveChangesAsync();
        }

    }
}


