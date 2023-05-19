
using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IEntradaOfeHabService
    {
        public Task<List<EntradaOfeHabVm>> GetAll();
        public Task<EntradaOfeHab> GetById(int id_oferta, int id_habilidad);
        public Task<EntradaOfeHab> Create(EntradaOfeHabVm ofertahabilidadRequest);
        public Task Delete(int id_oferta, int id_habilidad);
    }
}
