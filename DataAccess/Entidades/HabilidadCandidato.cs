using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entidades
{
    public class HabilidadCandidato
    {
        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; }
        public int HabilidadId { get; set; }


        public HabilidadesTecnicas HabilidadesTecnicas { get; set; }
    }
}
