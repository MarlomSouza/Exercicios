using Exercicio;
using Exercicio.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExercicioTest
{
    public class Teste
    {
        ICollatz collatz;

        public Teste()
        {
            collatz = new Collatz();
        }

        [Fact]
        public void QuantidadeSequenciaCollatz()
        {
            collatz.CalcularCollatz(7);
            Assert.Equal(17, collatz.CollatzNumbers.Count);

            collatz.CalcularCollatz(10);
            Assert.Equal(7, collatz.CollatzNumbers.Count);

            collatz.CalcularCollatz(13);
            Assert.Equal(10, collatz.CollatzNumbers.Count);
        }

        [Theory]
        [InlineData(10, 9, 20)]
        [InlineData(20, 18, 21)]
        [InlineData(1000000, 837799, 525)]
        public void Maior_Numero_Sequencial_collatz(long collatzNumeber, long maiorNumero, long maiorSequencia)
        {
            var _maiorSequencia = collatz.MaiorSequenciaCollatz(collatzNumeber);
            Assert.Equal(maiorNumero, collatz.MaiorNumero);
            Assert.Equal(maiorSequencia, _maiorSequencia);
        }

        [Fact]
        public void Inserindo_Numero_Corretamente_na_lista()
        {
            collatz.CalcularCollatz(6);
            IList<long> listaEsperada = new List<long>() { 6, 3, 10, 5, 16, 8, 4, 2, 1 };

            for (int i = 0; i < listaEsperada.Count; i++)
                Assert.Equal(listaEsperada[i], collatz.CollatzNumbers[i]);

            collatz.CalcularCollatz(13);
            listaEsperada = new List<long>() { 13, 40, 20, 10, 5, 16, 8, 4, 2, 1 };

            for (int i = 0; i < listaEsperada.Count; i++)
                Assert.Equal(listaEsperada[i], collatz.CollatzNumbers[i]);
        }

        [Fact]
        public void Lista_possui_apenas_numeros_pares() {
            IList<int> listaEsperada = new List<int>() { 2,4,6,8,10 };

            Assert.False(listaEsperada.ContainsOnlyOddNumbers());
        }

        [Fact]
        public void Lista_possui_apenas_numeros_impares()
        {
            IList<long> listaEsperada = new List<long>() { 1,3,5,7,9 };

            Assert.True(listaEsperada.ContainsOnlyOddNumbers());
        }

        [Fact]
        public void Lista_possui_numeros_impares_e_pares()
        {
            IList<decimal> listaEsperada = new List<decimal>() { 1,2,3,4,5,6 };

            Assert.False(listaEsperada.ContainsOnlyOddNumbers());
        }

        [Fact]
        public void numero_par()
        {
            Assert.Equal(false, 2.IsOdd());
        }

        [Fact]
        public void numero_impar()
        {
            Assert.Equal(true, 3.IsOdd());
        }




    }
}

