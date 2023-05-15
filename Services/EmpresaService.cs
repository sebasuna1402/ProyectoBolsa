
using DataAccess.Entidades;
using Microsoft.EntityFrameworkCore;
using ProyectoBolsa.Data;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    //replicar

    public class EmpresaService : IEmpresaService
    {
        private readonly MyApiContext _context;
        public EmpresaService(MyApiContext context)
        {
            _context = context;
        }

        public async Task<List<Empresa>> GetAll()
        {
         
            List<Empresa> listaEmpresas = await _context.Empresa
            .Include(c => c.ofertas)
            .Select(c => new Empresa
            {
                Id = c.Id,
                NombreEmpresa = c.NombreEmpresa,
                Direccion = c.Direccion,
                Telefono = c.Telefono,

                ofertas = c.ofertas.Select(f => new Oferta
                {
                    Descripcion = f.Descripcion,
                    HabilidadOfertas = f.HabilidadOfertas,
                    OfertaCandidatos = f.OfertaCandidatos,

                }).ToList(),
            })
                   .ToListAsync();

            //xd

            return listaEmpresas;
        }

        public async Task<Empresa> GetById(int id)
        {
              var empresa = await _context.Empresa
             .Include(c => c.ofertas)
             .FirstOrDefaultAsync(c => c.Id == id);

            return empresa;
        }
        public async Task<Empresa> Create(EmpresaVm empresaRequest)
        {
            Empresa newEmpresa = new Empresa();
            newEmpresa.Id = empresaRequest.Id;
            newEmpresa.NombreEmpresa = empresaRequest.NombreEmpresa;
            newEmpresa.Direccion = empresaRequest.Direccion;
            newEmpresa.Telefono = empresaRequest.Telefono;

            _context.Empresa.Add(newEmpresa);
            await _context.SaveChangesAsync();

            return newEmpresa;
        }




        //revisar
        public async Task Update(int id, EmpresaVm empresaRequest)
        {
            Empresa EmpresaEdit = await _context.Empresa.FindAsync(id);

            EmpresaEdit.NombreEmpresa = empresaRequest.NombreEmpresa;
            EmpresaEdit.Direccion = empresaRequest.Direccion;
            EmpresaEdit.Telefono = empresaRequest.Telefono;

            _context.Entry(EmpresaEdit).State = EntityState.Modified;
        
             await _context.SaveChangesAsync();         
        }
        public async Task Delete(int id)
        {
     
            var empresa = await _context.Empresa.FindAsync(id);

            _context.Empresa.Remove(empresa);
            await _context.SaveChangesAsync();
        }

    }
}
