using System.Collections.Generic;

namespace RH.Models
{
    public class Tecnologia
    {
        public Tecnologia()
        {
            Processos = new HashSet<ProcessoTecnologia>();
            Candidatos = new HashSet<CandidatoTecnologia>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<ProcessoTecnologia> Processos { get; set; }
        public ICollection<CandidatoTecnologia> Candidatos { get; set; }
    }
}
