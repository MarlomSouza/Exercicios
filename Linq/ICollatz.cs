using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio
{
    public interface ICollatz
    {

        List<int> CollatzNumbers { get; }

        void CalcularCollatz(int number);
        int MaiorSequenciaCollatz(int numero);
    }
}
