
using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IOfertaHabilidadService
    {
        public Task<List<HabilidadOfertaVm>> GetAll();
        public Task<HabilidadOferta> GetById(int id_oferta, int id_habilidad);
        public Task<HabilidadOferta> Create(HabilidadOfertaVm ofertahabilidadRequest);
        public Task Delete(int id_oferta, int id_habilidad);
    }
}
