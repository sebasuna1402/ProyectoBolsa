using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entidades
{
    public class Oferta
    {
        //creamos un id basicamente para la hora de eliminarlo o editarlo 
        public int Id { get; set; }
        public string Descripcion { get; set; }

        //basicamente llamamos a la empresa y su id ya que la oferta pertenece a esa empresa en especifico
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        public List<EntradaOfeHab> HabilidadOfertas { get; set; }
        public List<EntradaOferCa> OfertaCandidatos { get; set; }

    }
}
