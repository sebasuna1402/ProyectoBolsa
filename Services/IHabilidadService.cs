
using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IHabilidadService
    {
        public Task<List<HabilidadesTecnicasVm>> GetAll();

        public Task<HabilidadesTecnicas> GetById(int id);

        public Task<HabilidadesTecnicas> Create(HabilidadesTecnicasVm habilidadRequest);

        public Task Update(int id, HabilidadesTecnicasVm habilidadRequest);

        public Task Delete(int id);
    }
}
