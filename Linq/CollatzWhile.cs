using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio
{
    public class CollatzWhile : ICollatz
    {
        public List<int> CollatzNumbers { get; }

        public CollatzWhile()
        {
            CollatzNumbers = new List<int>();
        }

        public void CalcularCollatz(int number)
        {
            while (number != 1)
            {
                if (CollatzNumbers.Contains(number) == false)
                    CollatzNumbers.Add((number));

                number = CalculoCollatz(number);
            }
            CollatzNumbers.Add((number));
        }

        private int CalculoCollatz(int n)
        {
            if (n % 2 == 0)
                return n / 2;

            return 3 * n + 1;
        }

        public int MaiorSequenciaCollatz(int numero)
        {
            int maiorNumeroSequencial = 0;
            for (int i = 0; i < numero; i++)
            {
                if (CollatzNumbers.Contains(i))
                {
                    if (CollatzNumbers.IndexOf(i) > maiorNumeroSequencial                        )
                        maiorNumeroSequencial = CollatzNumbers.IndexOf(i);
                }
                else
                {
                    CalcularCollatz(i);
                }
            }
            return maiorNumeroSequencial;
        }
    }
}
