
using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ICandidatoOfertaService
    {
        public Task<List<OfertaCandidatoVm>> GetAll();
        public Task<OfertaCandidato> GetById(int id_candidato, int id_oferta);
        public Task<OfertaCandidato> Create(OfertaCandidatoVm candidatoofertaRequest);
        public Task Delete(int id_candidato, int id_oferta);
    }
}
//xd