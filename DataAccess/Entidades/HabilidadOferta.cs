using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entidades
{
    public class HabilidadOferta
    {
        public int OfertaId { get; set; }
        public Oferta Oferta { get; set; }
        public int HabilidadId { get; set; }
        public HabilidadesTecnicas HabilidadesTecnicas { get; set; }
    }
}
