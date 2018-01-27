using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio
{
    public class Collatz : ICollatz
    {
        public List<long> CollatzNumbers { get; }
        public long MaiorNumero { get; set; }

        public Collatz()
        {
            CollatzNumbers = new List<long>();
        }

        public void CalcularCollatz(long number)
        {
            if (CollatzNumbers.Contains(number))
            {
                CollatzNumbers.RemoveRange(0, CollatzNumbers.IndexOf(number));
                return;
            }

            if (number != 1)
            {
                if (number % 2 == 0)
                    CalcularCollatz(number / 2);
                else
                    CalcularCollatz(3 * number + 1);
            }
            CollatzNumbers.Insert(0, number);
        }

        public long MaiorSequenciaCollatz(long numero)
        {
            long maiorSequencia = 0;
            for (long i = 1; i <= numero; i++)
            {
                CalcularCollatz(i);
                if (CollatzNumbers.Count > maiorSequencia)
                {
                    maiorSequencia = CollatzNumbers.Count;
                    MaiorNumero = CollatzNumbers[0];
                }
            }

            return maiorSequencia;
        }
    }
}
