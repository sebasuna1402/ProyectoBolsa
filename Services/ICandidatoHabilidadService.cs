
using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ICandidatoHabilidadService
    {
        public Task<List<HabilidadCandidatoVm>> GetAll();
        public Task<HabilidadCandidato> GetById(int id_candidato, int id_habilidad);
        public Task<HabilidadCandidato> Create(HabilidadCandidatoVm candidatohabilidadRequest);
        public Task Delete(int id_candidato, int id_habilidad);
    }
}
