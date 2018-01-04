using Exercicio;
using Exercicio.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ExercicioTest
{
    public class TestExercicioB
    {

        [Fact]
        public void Lista_possui_apenas_numeros_pares()
        {
            IList<int> listaEsperada = new List<int>() { 2, 4, 6, 8, 10 };

            Assert.False(listaEsperada.ContainsOnlyOddNumbers());
        }

        [Fact]
        public void Lista_possui_apenas_numeros_impares()
        {
            IList<long> listaEsperada = new List<long>() { 1, 3, 5, 7, 9 };

            Assert.True(listaEsperada.ContainsOnlyOddNumbers());
        }

        [Fact]
        public void Lista_possui_numeros_impares_e_pares()
        {
            IList<decimal> listaEsperada = new List<decimal>() { 1, 2, 3, 4, 5, 6 };

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

        [Fact]
        public void item_nao_contem_na_outra_lista()
        {
            IEnumerable<int> lista_A = new List<int>() { 1, 3, 7, 29, 42, 98, 234, 93 };
            IEnumerable<int> lista_B = new List<int>() { 4, 6, 93, 7, 55, 32, 3 };
            IEnumerable<int> lista_C = new List<int>() { 1, 29, 42, 98, 234 };

            var lista_Resultado = lista_A.NotIn(lista_B);

            Assert.True(lista_C.SequenceEqual(lista_Resultado));
        }

        [Fact]
        public void item_contem_na_outra_lista()
        {
            IEnumerable<int> lista_A = new List<int>() { 1, 3, 7, 29, 42, 98, 234, 93 };
            IEnumerable<int> lista_B = new List<int>() { 4, 6, 93, 7, 55, 32, 3 };
            IEnumerable<int> lista_C = new List<int>() { 3, 7, 93 };

            var lista_Resultado = lista_A.In(lista_B);

            Assert.True(lista_C.SequenceEqual(lista_Resultado));
        }
    }
}
