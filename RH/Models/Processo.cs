using System.Collections.Generic;

namespace RH.Models
{
    public class Processo
    {
        public Processo()
        {
            Tecnologias = new HashSet<ProcessoTecnologia>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual Triagem Triagem { get; set; }
        public ICollection<ProcessoTecnologia> Tecnologias { get; set; }
    }
}
