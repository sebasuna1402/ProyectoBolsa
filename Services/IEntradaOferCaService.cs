
using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IEntradaOferCaService
    {
        public Task<List<EntradaOferCaVm>> GetAll();
        public Task<EntradaOferCa> GetById(int id_candidato, int id_oferta);
        public Task<EntradaOferCa> Create(EntradaOferCaVm candidatoofertaRequest);
        public Task Delete(int id_candidato, int id_oferta);
    }
}
//xd