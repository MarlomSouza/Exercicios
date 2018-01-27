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
            return lista.Where(item => item.IsOdd()).In(lista).SequenceEqual(lista);
        }

        public static bool ContainsOnlyOddNumbers(this IEnumerable<long> lista)
        {
            return lista.Where(item => item.IsOdd()).In(lista).SequenceEqual(lista);
        }

        public static bool ContainsOnlyOddNumbers(this IEnumerable<Decimal> lista)
        {
            return lista.Where(item => item.IsOdd()).In(lista).SequenceEqual(lista);
        }

        public static IList<T> NotIn<T>(this IEnumerable<T> lista_A, IEnumerable<T> lista_B)
        {
            return lista_A.Where(item => lista_B.Contains(item) == false).ToList();
        }

        public static IList<T> In<T>(this IEnumerable<T> lista_A, IEnumerable<T> lista_B)
        {
            return lista_A.Where(item => lista_B.Contains(item)).ToList();
        }


   




    }
}
