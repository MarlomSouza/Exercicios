using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using RH;
using RH.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace ExercicioTest.RH
{
    public class ProcessoTeste
    {

        private readonly TestServer _server;
        private readonly HttpClient _client;
        private readonly string API = "/api/Processos";
        private readonly string mediaType = "application/json";

        public ProcessoTeste()
        {
            _server = new TestServer(new WebHostBuilder()
            .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void Obter_processo_por_id()
        {
            // Act
            var processo = CriarProcessos();
            var processoJson = JsonConvert.SerializeObject(processo);
            var content = new StringContent(processoJson, Encoding.UTF8, mediaType);
            var resposta = await _client.PostAsync(API, content);
            var responseString = await resposta.Content.ReadAsStringAsync();
           processo = JsonConvert.DeserializeObject<Processo>(responseString);

            resposta = await _client.GetAsync(API + "/" + processo.Id);
            responseString = await resposta.Content.ReadAsStringAsync();
            var _processo = JsonConvert.DeserializeObject<Processo>(responseString);

            // Assert
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
            Assert.Equal(processo.Id, _processo.Id);
        }

        [Fact]
        public async void Obter_processo_inexistente()
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
            var processo = CriarProcessos();
            var processoJson = JsonConvert.SerializeObject(processo);
            HttpContent content = new StringContent(processoJson, Encoding.UTF8, mediaType);
            var resposta = await _client.PostAsync(API, content);
            var responseString = await resposta.Content.ReadAsStringAsync();
            var _processo = JsonConvert.DeserializeObject<Tecnologia>(responseString);

            // Assert
            Assert.Equal(HttpStatusCode.Created, resposta.StatusCode);
            Assert.Equal(processo.Nome, _processo.Nome);
        }

        [Fact]
        public async void Alterar_processo()
        {
            //Salvar processo
            var processo = CriarProcessos();
            var processoJson = JsonConvert.SerializeObject(processo);
            HttpContent content = new StringContent(processoJson, Encoding.UTF8, mediaType);
            var resposta = await _client.PostAsync(API, content);
            var responseString = await resposta.Content.ReadAsStringAsync();
            var _processo = JsonConvert.DeserializeObject<Tecnologia>(responseString);

            //Assert
            Assert.Equal(processo.Nome, _processo.Nome);

            //Altera processo
            processo = CriarProcessos( "Processo 00000");
            processo.Id = _processo.Id;
            processoJson = JsonConvert.SerializeObject(processo);
            content = new StringContent(processoJson, Encoding.UTF8, mediaType);
            resposta = await _client.PutAsync(API + "/" +  _processo.Id, content);

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, resposta.StatusCode);

            //Obter processo
            resposta = await _client.GetAsync(API + "/" + _processo.Id);
            responseString = await resposta.Content.ReadAsStringAsync();
            _processo = JsonConvert.DeserializeObject<Tecnologia>(responseString);

            //Assert
            Assert.Equal(processo.Nome, _processo.Nome);
        }

        [Fact]
        public async void Deletar_processo()
        {
            //Salvar processo
            var processo = CriarProcessos();
            var processoJson = JsonConvert.SerializeObject(processo);
            HttpContent content = new StringContent(processoJson, Encoding.UTF8, mediaType);
            var resposta = await _client.PostAsync(API, content);
            var responseString = await resposta.Content.ReadAsStringAsync();
            var _processo = JsonConvert.DeserializeObject<Tecnologia>(responseString);

            //Assert
            Assert.Equal(processo.Nome, _processo.Nome);

            resposta = await _client.DeleteAsync(API + "/" + _processo.Id);
            //Assert
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);

            resposta = await _client.GetAsync(API + "/" + _processo.Id);
            // Assert
            Assert.Equal(HttpStatusCode.NotFound, resposta.StatusCode);
        }



        public Processo CriarProcessos(string nome = "Processo ")
        {

            nome += new Random().Next();

            return new Processo() { Nome = nome };
        }



    }
}
