using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entidades
{
    public class Candidato : Persona
    {
        public int Id { get; set; }
      
        public string ResumenPersonal { get; set; }

        
        public List<FormacionAcademica> FormacionAcads { get; set; }
        public List<EntradaHabilidadCa> EntradaHabilidadCa { get; set; }
        public List<EntradaOferCa> EntradaOferCa { get; set; }
    }
}
