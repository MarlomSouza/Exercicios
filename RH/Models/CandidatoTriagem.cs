using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Models
{
    public class CandidatoTriagem
    {
        public int CandidatoId { get; set; }
        public int TriagemId { get; set; }
        public Candidato Candidato { get; set; }
        public Triagem Triagem { get; set; }


    }
}
