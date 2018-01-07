using Exercicio;
using System;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello word");

            Collatz collatz = new Collatz();
            collatz.MaiorSequenciaCollatz(1000000);
            Console.WriteLine(collatz.MaiorNumero  + " =  número inicial entre 1 e 1 milhão que produz a maior sequência \n");

            int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };

            Console.WriteLine("1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144. O seguinte array contém somente números ímpares? \n" + numeros.ContainsOnlyOddNumbers());

            int[] primeiroArray = { 1, 3, 7, 29, 42, 98, 234, 93 };
            int[] segundoArray = { 4, 6, 93, 7, 55, 32, 3 };

           var naoEstaContidoNoSegundo = primeiroArray.NotIn(segundoArray);

            Console.WriteLine("somente os números do primeiro array que não estejam contidos no segundo array");

            foreach (var item in naoEstaContidoNoSegundo)
            {
                Console.Write(item + "  ");
            }



            Console.ReadLine();

        }
    }
}
