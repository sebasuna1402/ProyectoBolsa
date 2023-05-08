using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entidades
{
    public class OfertaCandidato
    {
        public int CandidatoId { get; set; }

        //llamamos al candidadato
        public Candidato Candidato { get; set; }

        //creamos un id para poder borrar o actualizar
        public int OfertaId { get; set; }

        //llamamos la oferta 
        public Oferta Oferta { get; set; }
    }
}
