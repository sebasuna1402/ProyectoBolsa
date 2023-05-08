using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entidades
{
    public class HabilidadesTecnicas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }


        //listas

        public List<HabilidadCandidato> HabilidadCandidatos{ get; set; }
        public List<HabilidadOferta> HabilidadOfertas { get; set; }

    }
}
