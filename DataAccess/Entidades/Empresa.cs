using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entidades
{
    public class Empresa
    {

        public int Id { get; set; }
        public string NombreEmpresa { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }

        //relaciones

        public List<Oferta> ofertas { get; set; }



    }
}
