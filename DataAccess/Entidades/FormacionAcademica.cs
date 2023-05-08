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
        public int Años_Estudio { get; set; }
        public string Fecha_Culminacion { get; set; }

        //Relaciones
        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; }


    }
}
