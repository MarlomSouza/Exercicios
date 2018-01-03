using Exercicio.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercicio
{
    public static class ListHelper
    {
        public static bool ContainsOnlyOddNumbers(this IEnumerable<int> lista)
        {
            return lista.Any(item => item.IsOdd());
        }

        public static bool ContainsOnlyOddNumbers(this IEnumerable<long> lista)
        {
            return lista.Any(item => item.IsOdd());
        }

        public static bool ContainsOnlyOddNumbers(this IEnumerable<Decimal> lista)
        {
            return lista.Any(item => item.IsOdd());
        }


    }
}
