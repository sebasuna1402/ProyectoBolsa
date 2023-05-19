
using DataAccess.Entidades;
using Microsoft.EntityFrameworkCore;
using ProyectoBolsa.Data;
using Services.IServices;


namespace Services.Services
{
    public class EntradaOferCaService : IEntradaOferCaService
    {
        private readonly MyApiContext _context;

        public EntradaOferCaService(MyApiContext context)
        {
            _context = context;
        }
        public async Task<List<EntradaOferCaVm>> GetAll()
        {

            List<EntradaOferCa> listaCandidatoOferta = await _context.OfertaCandidato.ToListAsync();

            List<EntradaOferCaVm> listaCandidatoOfertaVm = new List<EntradaOferCaVm>();

            foreach (EntradaOferCa candidatoOferta in listaCandidatoOferta)
            {
                EntradaOferCaVm newCandidatoOfertaVm = new EntradaOferCaVm();
                newCandidatoOfertaVm.CandidatoId = candidatoOferta.CandidatoId;
                newCandidatoOfertaVm.OfertaId = candidatoOferta.OfertaId;
                listaCandidatoOfertaVm.Add(newCandidatoOfertaVm);
            }

            return listaCandidatoOfertaVm;
        }

        public async Task<EntradaOferCa> GetById(int id_candidato, int id_oferta)
        {
            EntradaOferCa newOfertaCandidato = new EntradaOferCa();
            newOfertaCandidato = _context.OfertaCandidato.SingleOrDefault(pc => pc.CandidatoId == id_candidato && pc.OfertaId == id_oferta);

            return newOfertaCandidato;
        }

        public async Task<EntradaOferCa> Create(EntradaOferCaVm ofertacandidatoRequest)
        {
            EntradaOferCa newOfertaCandidato = new EntradaOferCa();
            newOfertaCandidato.CandidatoId = ofertacandidatoRequest.CandidatoId;
            newOfertaCandidato.OfertaId = ofertacandidatoRequest.OfertaId;

         

            _context.OfertaCandidato.Add(newOfertaCandidato);
            await _context.SaveChangesAsync();

            return newOfertaCandidato;

        }

        public async Task Delete(int id_candidato, int id_oferta)
        {

            EntradaOferCa newOfertaCandidato = new EntradaOferCa();
            newOfertaCandidato = _context.OfertaCandidato.SingleOrDefault(pc => pc.CandidatoId == id_candidato && pc.OfertaId == id_oferta);

            _context.OfertaCandidato.Remove(newOfertaCandidato);
            await _context.SaveChangesAsync();
        }
    }
}
