using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using RH;
using RH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace ExercicioTest.RH
{
    public class TecnologiaTeste
    {

        private readonly TestServer _server;
        private readonly HttpClient _client;
        private readonly string API = "/api/Tecnologias";
        private readonly string mediaType = "application/json";

        public TecnologiaTeste()
        {
            _server = new TestServer(new WebHostBuilder()
            .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void Obter_tecnologia_por_id()
        {
            // Act
            var tecnologia = CriarTecnologia(2, "C#");
            var tecnologiaJson = JsonConvert.SerializeObject(tecnologia);
            var content = new StringContent(tecnologiaJson, Encoding.UTF8, mediaType);
            var resposta = await _client.PostAsync(API, content);

            resposta = await _client.GetAsync(API + "/2");
            var responseString = await resposta.Content.ReadAsStringAsync();
            var _tecnologia = JsonConvert.DeserializeObject<Tecnologia>(responseString);

            // Assert
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
            Assert.Equal(tecnologia.Id, _tecnologia.Id);
        }

        [Fact]
        public async void Obter_tecnologia_inexistente()
        {
            // Act
            var resposta = await _client.GetAsync(API + "/0");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, resposta.StatusCode);
        }

        [Fact]
        public async void Cadastrar_Usuario()
        {
            //Act
            var tecnologia = CriarTecnologia(5, "C#");
            var tecnologiaJson = JsonConvert.SerializeObject(tecnologia);
            HttpContent content = new StringContent(tecnologiaJson, Encoding.UTF8, mediaType);
            var resposta = await _client.PostAsync(API, content);

            var responseString = await resposta.Content.ReadAsStringAsync();
            var _tecnologia = JsonConvert.DeserializeObject<Tecnologia>(responseString);

            // Assert
            Assert.Equal(HttpStatusCode.Created, resposta.StatusCode);
            Assert.Equal(tecnologia.Nome, _tecnologia.Nome);
        }

        [Fact]
        public async void Alterar_tecnologia()
        {
            //Salvar tecnologia
            var tecnologia = CriarTecnologia(3, "java");
            var tecnologiaJson = JsonConvert.SerializeObject(tecnologia);
            HttpContent content = new StringContent(tecnologiaJson, Encoding.UTF8, mediaType);
            var resposta = await _client.PostAsync(API, content);
            var responseString = await resposta.Content.ReadAsStringAsync();
            var _tecnologia = JsonConvert.DeserializeObject<Tecnologia>(responseString);

            //Assert
            Assert.Equal(tecnologia.Nome, _tecnologia.Nome);

            //Altera tecnologia
            tecnologia = CriarTecnologia(id: 3);
            tecnologiaJson = JsonConvert.SerializeObject(tecnologia);
            content = new StringContent(tecnologiaJson, Encoding.UTF8, mediaType);
            resposta = await _client.PutAsync(API + "/3", content);

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, resposta.StatusCode);

            //Obter tecnologia
            resposta = await _client.GetAsync(API + "/3");
            responseString = await resposta.Content.ReadAsStringAsync();
            _tecnologia = JsonConvert.DeserializeObject<Tecnologia>(responseString);

            //Assert
            Assert.Equal(tecnologia.Nome, _tecnologia.Nome);
        }

        [Fact]
        public async void Deletar_tecnologia()
        {
            //Salvar tecnologia
            var tecnologia = CriarTecnologia(4);
            var tecnologiaJson = JsonConvert.SerializeObject(tecnologia);
            HttpContent content = new StringContent(tecnologiaJson, Encoding.UTF8, mediaType);
            var resposta = await _client.PostAsync(API, content);
            var responseString = await resposta.Content.ReadAsStringAsync();
            var _tecnologia = JsonConvert.DeserializeObject<Tecnologia>(responseString);

            //Assert
            Assert.Equal(tecnologia.Nome, _tecnologia.Nome);

            resposta = await _client.DeleteAsync(API + "/4");
            //Assert
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);

            resposta = await _client.GetAsync(API + "/4");
            // Assert
            Assert.Equal(HttpStatusCode.NotFound, resposta.StatusCode);
        }

        private IList<Tecnologia> ListaTecnologias(int quantidadeTecnologiasConhecidas)
        {
            var lista = new List<Tecnologia>(){
                CriarTecnologia(1 ,"C#"),
                CriarTecnologia(1 ,"Java"),
                CriarTecnologia(1, "Ruby"),
                CriarTecnologia(1 ,"PHP"),
                CriarTecnologia(1 ,"ANGULAR"),
                CriarTecnologia(1 ,"Angular 2"),
                CriarTecnologia(1 ,"Javascript"),
                CriarTecnologia(1 ,"Knockout"),
                CriarTecnologia(1 ,"Visual basic"),
                CriarTecnologia(1 ,"Git"),
                CriarTecnologia(1 ,"Git"),
                CriarTecnologia(1 ,"Asp Net core"),
                CriarTecnologia(1 ,"SQL"),
                CriarTecnologia(1 ,"node"),
                CriarTecnologia(1 ,"python")
            };
            var listaAleatoria = NumerosAleatorios(quantidadeTecnologiasConhecidas);
            var listaSelecionados = lista.Where(t => listaAleatoria.Contains(t.Id)).ToList();
            return listaSelecionados;
        }

        public Tecnologia CriarTecnologia(Nullable<int> id = null, string nome = "C#")
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
