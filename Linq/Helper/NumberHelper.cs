using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercicio.Helper
{
    public static class NumberHelper
    {
        public static bool IsOdd(this Int32 number)
        {
            return number % 2 != 0;
        }
        public static bool IsOdd(this Int64 number)
        {
            return number % 2 != 0;
        }

        public static bool IsOdd(this Decimal number)
        {
            return number % 2 != 0;
        }
    }
}
