using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Models
{
    public class Processo
    {
        public Processo()
        {
            Tecnologias = new HashSet<ProcessoTecnologia>();
            Candidatos = new HashSet<CandidatoProcesso>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<ProcessoTecnologia> Tecnologias { get; set; }
        public ICollection<CandidatoProcesso> Candidatos { get; set; }
    }
}
