using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Models
{
    public class CandidatoProcesso
    {
        public int CandidatoId { get; set; }
        public int ProcessoId { get; set; }
        public Candidato Candidato { get; set; }
        public Processo Processo { get; set; }


    }
}
