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
            var tecnologia = CriarTecnologia("C#");
            var tecnologiaJson = JsonConvert.SerializeObject(tecnologia);
            var content = new StringContent(tecnologiaJson, Encoding.UTF8, mediaType);
            var resposta = await _client.PostAsync(API, content);
            var responseString = await resposta.Content.ReadAsStringAsync();
            tecnologia = JsonConvert.DeserializeObject<Tecnologia>(responseString);


            resposta = await _client.GetAsync(API + "/" + tecnologia.Id);
            responseString = await resposta.Content.ReadAsStringAsync();
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
            var tecnologia = CriarTecnologia("C#");
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
            var tecnologia = CriarTecnologia("java");
            var tecnologiaJson = JsonConvert.SerializeObject(tecnologia);
            HttpContent content = new StringContent(tecnologiaJson, Encoding.UTF8, mediaType);
            var resposta = await _client.PostAsync(API, content);
            var responseString = await resposta.Content.ReadAsStringAsync();
            var _tecnologia = JsonConvert.DeserializeObject<Tecnologia>(responseString);

            //Assert
            Assert.Equal(tecnologia.Nome, _tecnologia.Nome);

            //Altera tecnologia
            tecnologia = CriarTecnologia();
            tecnologia.Id = _tecnologia.Id;
            tecnologiaJson = JsonConvert.SerializeObject(tecnologia);
            content = new StringContent(tecnologiaJson, Encoding.UTF8, mediaType);
            resposta = await _client.PutAsync(API + "/" + _tecnologia.Id, content);

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, resposta.StatusCode);

            //Obter tecnologia
            resposta = await _client.GetAsync(API + "/" + _tecnologia.Id);
            responseString = await resposta.Content.ReadAsStringAsync();
            _tecnologia = JsonConvert.DeserializeObject<Tecnologia>(responseString);

            //Assert
            Assert.Equal(tecnologia.Nome, _tecnologia.Nome);
        }

        [Fact]
        public async void Deletar_tecnologia()
        {
            //Salvar tecnologia
            var tecnologia = CriarTecnologia();
            var tecnologiaJson = JsonConvert.SerializeObject(tecnologia);
            HttpContent content = new StringContent(tecnologiaJson, Encoding.UTF8, mediaType);
            var resposta = await _client.PostAsync(API, content);
            var responseString = await resposta.Content.ReadAsStringAsync();
            var _tecnologia = JsonConvert.DeserializeObject<Tecnologia>(responseString);

            //Assert
            Assert.Equal(tecnologia.Nome, _tecnologia.Nome);

            resposta = await _client.DeleteAsync(API + "/" + _tecnologia.Id);
            //Assert
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);

            resposta = await _client.GetAsync(API + "/" + _tecnologia.Id);
            // Assert
            Assert.Equal(HttpStatusCode.NotFound, resposta.StatusCode);
        }

       

        public Tecnologia CriarTecnologia( string nome = "C#")
        {

            return new Tecnologia() { Nome = nome };
        }

    

    }
}
