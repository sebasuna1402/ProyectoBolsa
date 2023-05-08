using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OfertaVm
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        //relaciones
        public int EmpresaId { get; set; }

    }
}
