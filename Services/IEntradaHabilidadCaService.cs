
using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IEntradaHabilidadCaService
    {
        public Task<List<EntradaHabilidadCaVm>> GetAll();
        public Task<EntradaHabilidadCa> GetById(int id_candidato, int id_habilidad);
        public Task<EntradaHabilidadCa> Create(EntradaHabilidadCaVm candidatohabilidadRequest);
        public Task Delete(int id_candidato, int id_habilidad);
    }
}
