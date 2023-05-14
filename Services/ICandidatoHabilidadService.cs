﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ICandidatoHabilidadService
    {
        public Task<List<CandidatoHabilidadVm>> GetAll();
        public Task<CandidatoHabilidad> GetById(int id_candidato, int id_habilidad);
        public Task<CandidatoHabilidad> Create(CandidatoHabilidadVm candidatohabilidadRequest);
        public Task Delete(int id_candidato, int id_habilidad);
    }
}
