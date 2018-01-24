using System.Collections.Generic;

namespace RH.Models
{
    public class Candidato
    {
        public Candidato()
        {
            Tecnologias = new HashSet<CandidatoTecnologia>();
            Triagens = new HashSet<CandidatoTriagem>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<CandidatoTecnologia> Tecnologias { get; set; }
        public ICollection<CandidatoTriagem> Triagens { get; set; }
    }
}
