using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entidades
{
    public class Persona

    {
        // Clase padre que hereda atributos a la clase candidato
        public string Nombre { get; set; }

        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
    }
}
