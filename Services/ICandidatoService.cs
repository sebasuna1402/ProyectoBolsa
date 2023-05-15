﻿
using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ICandidatoService
    {
        public Task<List<Candidato>> GetAll();

        public Task<Candidato> GetById(int id);

        public Task<Candidato> Create(CandidatoVm candidatoRequest);

        public Task Update(int id, CandidatoVm candidatoRequest);

        public Task Delete(int id);

    }
}
//xd