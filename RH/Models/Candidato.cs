using System.Collections.Generic;

namespace RH.Models
{
    public class Candidato
    {
        public Candidato()
        {
            Tecnologias = new HashSet<CandidatoTecnologia>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<CandidatoTecnologia> Tecnologias { get; set; }
    }
}
