using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio
{
    public interface ICollatz
    {

        List<long> CollatzNumbers { get; }
        long MaiorNumero { get; set; }

        void CalcularCollatz(long number);
        long MaiorSequenciaCollatz(long numero);
    }
}
