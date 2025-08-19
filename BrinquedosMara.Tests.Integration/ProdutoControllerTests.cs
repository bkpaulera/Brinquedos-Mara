using System.Net;
using System.Net.Http.Json;
using BrinquedosMara.Core.Models;
using BrinquedosMara.Domain.Requests;
using BrinquedosMara.Domain.Responses;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace BrinquedosMara.Tests.Integration
{
    public class ProdutoControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ProdutoControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllAsync_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/produto");
            var wrapper = await response.Content.ReadFromJsonAsync<Response<List<Produto>>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(wrapper);
            Assert.NotNull(wrapper.Data);
            Assert.True(wrapper.IsSuccess);
        }



        [Fact]
        public async Task CreateProdutoAsync_ReturnsCreated()
        {
            var produto = new ProdutoRequest
            {
                Title = "Produto Teste",
                CodigoCatalogo = "CAT123",
                Description = "Descrição Teste",
                Image = "imagem.png"
            };
            var response = await _client.PostAsJsonAsync("/api/produto", produto);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        }

        [Fact]
        public async Task GetByIdAsync_ReturnsOkOrNotFound()
        {
            // Primeiro cria um produto
            var produto = new ProdutoRequest
            {
                Title = "Produto Teste",
                CodigoCatalogo = "CAT123",
                Description = "Descrição Teste",
                Image = "imagem.png"
            };
            var createResponse = await _client.PostAsJsonAsync("/api/produto", produto);
            var created = await createResponse.Content.ReadFromJsonAsync<Produto>();
            var response = await _client.GetAsync($"/api/produto/{created.Id}");
            Assert.True(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateProdutoAsync_ReturnsNoContentOrBadRequest()
        {
            // Cria produto
            var produto = new ProdutoRequest
            {
                Title = "Produto Teste",
                CodigoCatalogo = "CAT123",
                Description = "Descrição Teste",
                Image = "imagem.png"
            };
            var createResponse = await _client.PostAsJsonAsync("/api/produto", produto);
            var created = await createResponse.Content.ReadFromJsonAsync<Produto>();
            // Atualiza produto
            var updateRequest = new ProdutoRequest
            {
                Id = created.Id,
                Title = "Produto Atualizado",
                CodigoCatalogo = "CAT123",
                Description = "Descrição Atualizada",
                Image = "imagem2.png"
            };
            var response = await _client.PutAsJsonAsync($"/api/produto/{created.Id}", updateRequest);
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task DeleteProdutoAsync_ReturnsNoContentOrNotFound()
        {
            // Cria produto
            var produto = new ProdutoRequest
            {
                Title = "Produto Teste",
                CodigoCatalogo = "CAT123",
                Description = "Descrição Teste",
                Image = "imagem.png"
            };
            var createResponse = await _client.PostAsJsonAsync("/api/produto", produto);
            var created = await createResponse.Content.ReadFromJsonAsync<Produto>();
            // Remove produto
            var response = await _client.DeleteAsync($"/api/produto/{created.Id}");
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.NotFound);
        }
    }
}