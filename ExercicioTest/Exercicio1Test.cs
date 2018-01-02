using Exercicio;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExercicioTest
{


    public class Exercicio1Test
    {
        ICollatz collatzRecursao;
        ICollatz collatzWhile;

        public Exercicio1Test()
        {
            collatzWhile = new CollatzWhile();
            collatzRecursao = new CollatzRescursao();
        }

        [Fact]
        public void QuantidadeSequenciaCollatz_13_Test()
        {
            collatzRecursao.CalcularCollatz(13);
            collatzWhile.CalcularCollatz(13);
            Assert.Equal(10, collatzRecursao.CollatzNumbers.Count);
            Assert.Equal(10, collatzWhile.CollatzNumbers.Count);
        }

        [Fact]
        public void Inserindo_Numero_Corretamente_na_lista()
        {
            collatzRecursao.CollatzNumbers.Clear();
            collatzWhile.CollatzNumbers.Clear();
            IList<int> listaEsperada = new List<int>() { 13, 40, 20, 10, 5, 16, 8, 4, 2, 1 };

            collatzRecursao.CalcularCollatz(13);
            collatzWhile.CalcularCollatz(13);

            Assert.Equal(listaEsperada[0], collatzRecursao.CollatzNumbers[0]);
            Assert.Equal(listaEsperada[0], collatzWhile.CollatzNumbers[0]);
            Assert.Equal(listaEsperada[listaEsperada.Count - 1], collatzRecursao.CollatzNumbers[collatzRecursao.CollatzNumbers.Count - 1]);
            Assert.Equal(listaEsperada[listaEsperada.Count - 1], collatzWhile.CollatzNumbers[collatzWhile.CollatzNumbers.Count - 1]);
        }

        //[Fact]
        public void Maior_Numero_Sequencial_collatz_entre_1_e_1000()
        {
            var numero = collatzRecursao.MaiorSequenciaCollatz(1000);
            Assert.Equal(112, numero);
        }

        [Fact]
        public void Maior_Numero_Sequencial_collatz_entre_1_e_20()
        {
            var numero = collatzRecursao.MaiorSequenciaCollatz(20);
            Assert.Equal(9, numero);
        }


        //[Fact]
        public void Maior_Numero_Sequencial_collatz_entre_1_e_1000000()
        {

            var numero = collatzRecursao.MaiorSequenciaCollatz(300000);

            Assert.Equal(9, numero);
        }   
    }
}

