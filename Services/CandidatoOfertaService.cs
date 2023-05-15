
using DataAccess.Entidades;
using Microsoft.EntityFrameworkCore;
using ProyectoBolsa.Data;
using Services.IServices;


namespace Services.Services
{
    public class CandidatoOfertaService : ICandidatoOfertaService
    {
        private readonly MyApiContext _context;

        public CandidatoOfertaService(MyApiContext context)
        {
            _context = context;
        }
        public async Task<List<OfertaCandidatoVm>> GetAll()
        {

            List<OfertaCandidato> listaCandidatoOferta = await _context.OfertaCandidato.ToListAsync();

            List<OfertaCandidatoVm> listaCandidatoOfertaVm = new List<OfertaCandidatoVm>();

            foreach (OfertaCandidato candidatoOferta in listaCandidatoOferta)
            {
                OfertaCandidatoVm newCandidatoOfertaVm = new OfertaCandidatoVm();
                newCandidatoOfertaVm.CandidatoId = candidatoOferta.CandidatoId;
                newCandidatoOfertaVm.OfertaId = candidatoOferta.OfertaId;
                listaCandidatoOfertaVm.Add(newCandidatoOfertaVm);
            }

            return listaCandidatoOfertaVm;
        }

        public async Task<OfertaCandidato> GetById(int id_candidato, int id_oferta)
        {
            OfertaCandidato newOfertaCandidato = new OfertaCandidato();
            newOfertaCandidato = _context.OfertaCandidato.SingleOrDefault(pc => pc.CandidatoId == id_candidato && pc.OfertaId == id_oferta);

            return newOfertaCandidato;
        }

        public async Task<OfertaCandidato> Create(OfertaCandidatoVm ofertacandidatoRequest)
        {
            OfertaCandidato newOfertaCandidato = new OfertaCandidato();
            newOfertaCandidato.CandidatoId = ofertacandidatoRequest.CandidatoId;
            newOfertaCandidato.OfertaId = ofertacandidatoRequest.OfertaId;

         

            _context.OfertaCandidato.Add(newOfertaCandidato);
            await _context.SaveChangesAsync();

            return newOfertaCandidato;

        }

        public async Task Delete(int id_candidato, int id_oferta)
        {

            OfertaCandidato newOfertaCandidato = new OfertaCandidato();
            newOfertaCandidato = _context.OfertaCandidato.SingleOrDefault(pc => pc.CandidatoId == id_candidato && pc.OfertaId == id_oferta);

            _context.OfertaCandidato.Remove(newOfertaCandidato);
            await _context.SaveChangesAsync();
        }
    }
}
