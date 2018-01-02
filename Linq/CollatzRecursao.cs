using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio
{
    public class CollatzRescursao : ICollatz
    {
        public List<int> CollatzNumbers { get; }
        public CollatzRescursao()
        {
            CollatzNumbers = new List<int>();
        }


        public void CalcularCollatz(int number)
        {
            if (CollatzNumbers.Contains(number))
                return;

            if (number != 1)
            {
                if (number % 2 == 0)
                    CalcularCollatz(number / 2);
                else
                    CalcularCollatz(3 * number + 1);
            }
            CollatzNumbers.Insert(0, number);

        }

        public int MaiorSequenciaCollatz(int numero)
        {
            int quantidadeNumeroSequenciais = 0;
            int valor = 0;
            for (int i = 1; i <= numero; i++)
            {
                if (CollatzNumbers.Contains(i))
                {
                    CollatzNumbers.RemoveRange(0, CollatzNumbers.IndexOf(i));
                }
                else
                {
                    CalcularCollatz(i);
                }

                if (CollatzNumbers.Count > quantidadeNumeroSequenciais)
                {
                    quantidadeNumeroSequenciais = CollatzNumbers.Count;
                    valor = CollatzNumbers[0];
                }
            }

            return valor;

        }

    }
}
