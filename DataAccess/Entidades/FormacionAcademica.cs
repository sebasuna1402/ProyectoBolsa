using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entidades
{
    public class FormacionAcademica
    {
        public int Id { get; set; }

        public string Formacion { get; set; }
        public int AñosEstudio { get; set; }
        public string FechaFinalizacion { get; set; }

        //Relaciones
        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; }


    }
}
