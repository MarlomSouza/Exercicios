using Exercicio;
using Exercicio.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
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

            Assert.True(listaEsperada.SequenceEqual(collatz.CollatzNumbers));

            collatz.CalcularCollatz(13);
            listaEsperada = new List<long>() { 13, 40, 20, 10, 5, 16, 8, 4, 2, 1 };

            Assert.True(listaEsperada.SequenceEqual(collatz.CollatzNumbers));
        }
    }
}

