
using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IFormacionService
    {

        public Task<FormacionAcademica> GetById(int id);

        public Task<FormacionAcademica> Create(FormacionAcademicaVm formacionRequest);

        public Task Update(int id, FormacionAcademicaVm formacionRequest);

        public Task Delete(int id);
    }
}
