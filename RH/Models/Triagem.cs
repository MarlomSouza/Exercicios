using System.Collections.Generic;

namespace RH.Models
{
    public class Triagem
    {
        public Triagem()
        {
            Candidatos = new HashSet<CandidatoTriagem>();
        }

        public int Id { get; set; }
        public int ProcessoId { get; set; }
        public Processo Processo { get; set; }
        public ICollection<CandidatoTriagem> Candidatos { get; set; }
    }
}