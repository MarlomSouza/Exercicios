using System.Collections.Generic;

namespace RH.Models
{
    public class Candidato
    {
        public Candidato()
        {
            Tecnologias = new HashSet<CandidatoTecnologia>();
            ProcessosSeletivos = new HashSet<CandidatoProcesso>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<CandidatoTecnologia> Tecnologias { get; set; }
        public IEnumerable<CandidatoProcesso> ProcessosSeletivos { get; set; }
    }
}
