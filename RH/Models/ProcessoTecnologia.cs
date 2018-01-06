
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Models
{
    public class ProcessoTecnologia
    {
        public int ProcessoId { get; set; }
        public int TecnologiaId { get; set; }

        public int Peso { get; set; }

        public virtual Processo Processo { get; set; }
        public virtual Tecnologia Tecnologia { get; set; }
    }
}
