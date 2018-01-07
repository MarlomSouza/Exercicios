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

namespace ExercicioTest
{
    public class CandidatoTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private readonly string API = "/api/Candidatos";
        private readonly string mediaType = "application/json";

        public CandidatoTest()
        {

            _server = new TestServer(new WebHostBuilder()
            .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void Obter_candidato_por_id()
        {
            // Act
            var candidato = CriarCandidato();
            var candidatoJson = JsonConvert.SerializeObject(candidato);
            var content = new StringContent(candidatoJson, Encoding.UTF8, mediaType);
            var resposta = await _client.PostAsync(API, content);

            var responseString = await resposta.Content.ReadAsStringAsync();
            candidato = JsonConvert.DeserializeObject<Candidato>(responseString);

            resposta = await _client.GetAsync(API + "/" + candidato.Id);
            responseString = await resposta.Content.ReadAsStringAsync();
            var _candidato = JsonConvert.DeserializeObject<Candidato>(responseString);

            // Assert
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
            Assert.Equal(candidato.Id, _candidato.Id);
        }

        [Fact]
        public async void Obter_candidato_inexistente()
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
            Candidato candidato = CriarCandidato();
            var candidatoJson = JsonConvert.SerializeObject(candidato);
            HttpContent content = new StringContent(candidatoJson, Encoding.UTF8, mediaType);
            var resposta = await _client.PostAsync(API, content);

            var responseString = await resposta.Content.ReadAsStringAsync();
            Candidato _candidato = JsonConvert.DeserializeObject<Candidato>(responseString);

            // Assert
            Assert.Equal(HttpStatusCode.Created, resposta.StatusCode);
            Assert.Equal(candidato.Nome, _candidato.Nome);
        }

        [Fact]
        public async void Alterar_candidato()
        {
            //Salvar candidato
            Candidato candidato = CriarCandidato();
            var candidatoJson = JsonConvert.SerializeObject(candidato);
            HttpContent content = new StringContent(candidatoJson, Encoding.UTF8, mediaType);
            var resposta = await _client.PostAsync(API, content);
            var responseString = await resposta.Content.ReadAsStringAsync();
            var _candidato = JsonConvert.DeserializeObject<Candidato>(responseString);

            //Assert
            Assert.Equal(candidato.Nome, _candidato.Nome);

            //Altera candidato
            candidato = CriarCandidato(nome: "Marlom");
            candidato.Id = _candidato.Id;
            candidatoJson = JsonConvert.SerializeObject(candidato);
            content = new StringContent(candidatoJson, Encoding.UTF8, mediaType);
            resposta = await _client.PutAsync(API + "/" + _candidato.Id, content);

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, resposta.StatusCode);

            //Obter candidato
            resposta = await _client.GetAsync(API + "/" + candidato.Id);
            responseString = await resposta.Content.ReadAsStringAsync();
            _candidato = JsonConvert.DeserializeObject<Candidato>(responseString);

            //Assert
            Assert.Equal(candidato.Nome, _candidato.Nome);
        }

        [Fact]
        public async void Deletar_Candidato()
        {
            //Salvar candidato
            Candidato candidato = CriarCandidato();
            var candidatoJson = JsonConvert.SerializeObject(candidato);
            HttpContent content = new StringContent(candidatoJson, Encoding.UTF8, mediaType);
            var resposta = await _client.PostAsync(API, content);
            var responseString = await resposta.Content.ReadAsStringAsync();
            var _candidato = JsonConvert.DeserializeObject<Candidato>(responseString);

            //Assert
            Assert.Equal(candidato.Nome, _candidato.Nome);

            resposta = await _client.DeleteAsync(API + "/" + _candidato.Id);
            //Assert
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);

            resposta = await _client.GetAsync(API + "/" + _candidato.Id);
            // Assert
            Assert.Equal(HttpStatusCode.NotFound, resposta.StatusCode);

        }

        private Candidato CriarCandidato(Nullable<int> id = null, string nome = "Pedro")
        {
            return new Candidato() { Nome = nome };

        }
    }
}
