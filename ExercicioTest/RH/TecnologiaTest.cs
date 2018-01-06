using RH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExercicioTest.RH
{
    public class TecnologiaTeste
    {





        private IList<Tecnologia> ListaTecnologias(int quantidadeTecnologiasConhecidas)
        {
            var lista = new List<Tecnologia>(){
                CreateTecnologi(1 ,"C#"),
                CreateTecnologi(1 ,"Java"),
                CreateTecnologi(1, "Ruby"),
                CreateTecnologi(1 ,"PHP"),
                CreateTecnologi(1 ,"ANGULAR"),
                CreateTecnologi(1 ,"Angular 2"),
                CreateTecnologi(1 ,"Javascript"),
                CreateTecnologi(1 ,"Knockout"),
                CreateTecnologi(1 ,"Visual basic"),
                CreateTecnologi(1 ,"Git"),
                CreateTecnologi(1 ,"Git"),
                CreateTecnologi(1 ,"Asp Net core"),
                CreateTecnologi(1 ,"SQL"),
                CreateTecnologi(1 ,"node"),
                CreateTecnologi(1 ,"python")
            };
            var listaAleatoria = NumerosAleatorios(quantidadeTecnologiasConhecidas);
            var listaSelecionados = lista.Where(t => listaAleatoria.Contains(t.Id)).ToList();
            return listaSelecionados;
        }

        public Tecnologia CreateTecnologi(Nullable<int> id = null, string nome = " ")
        {
            if (id.HasValue)
                return new Tecnologia() { Id = id.Value, Nome = nome };

            return new Tecnologia() { Nome = nome };
        }

        private IList<int> NumerosAleatorios(int quantidadeTecnologiasConhecidas)
        {
            List<int> lista = new List<int>();
            for (int i = 0; i <= quantidadeTecnologiasConhecidas; i++)
            {
                var numero = new Random().Next(1, 15);
                while (lista.Contains(numero))
                {
                    numero = new Random().Next(1, 15);
                }

                lista.Add(numero);
            }
            return lista;
        }

    }
}
