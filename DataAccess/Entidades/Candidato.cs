using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entidades
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string ResumenPersonal { get; set; }

        
        public List<FormacionAcademica> FormacionAcademicas { get; set; }
        public List<HabilidadCandidato> HabilidadCandidatos { get; set; }
        public List<OfertaCandidato> OfertaCandidatos { get; set; }
    }
}
