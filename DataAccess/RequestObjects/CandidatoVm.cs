﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CandidatoVm
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string ResumenPersonal { get; set; }

    }
}
