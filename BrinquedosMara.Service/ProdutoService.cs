using BrinquedosMara.Core.Models;
using BrinquedosMara.Domain.Repository;
using BrinquedosMara.Domain.Repository.BrinquedosMara.Domain.Repository;
using BrinquedosMara.Domain.Requests;
using BrinquedosMara.Domain.Responses;
using BrinquedosMara.Domain.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrinquedosMara.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Response<Produto>> CreateProdutoAsync(ProdutoRequest request)
        {
            try
            {
                var produto = new Produto
                {
                    Title = request.Title,
                    Description = request.Description,
                    CodigoCatalogo = request.CodigoCatalogo,
                    Image = request.Image
                };

                var produtoCriado = await _produtoRepository.CreateAsync(produto);
                return new Response<Produto>(produtoCriado, 201, "Produto criado com sucesso!");
            }
            catch (Exception ex)
            {
                return new Response<Produto>(null, 500, $"Erro ao criar produto: {ex.Message}");
            }
        }

        public async Task<Response<bool>> DeleteProdutoAsync(long id)
        {
            try
            {
                var result = await _produtoRepository.DeleteAsync(id);
                if (!result)
                    return new Response<bool>(false, 404, "Produto não encontrado.");

                return new Response<bool>(true, 200, "Produto removido com sucesso.");
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, 500, $"Erro ao excluir produto: {ex.Message}");
            }
        }

        public async Task<Response<IList<Produto>>> GetAllAsync()
        {
            try
            {
                var produtos = await _produtoRepository.GetAllAsync();
                return new Response<IList<Produto>>(produtos, 200, "Produtos carregados com sucesso.");
            }
            catch (Exception ex)
            {
                return new Response<IList<Produto>>(null, 500, $"Erro ao buscar produtos: {ex.Message}");
            }
        }

        public async Task<Response<Produto>> GetByIdAsync(long id)
        {
            try
            {
                var produto = await _produtoRepository.GetByIdAsync(id);
                if (produto == null)
                    return new Response<Produto>(null, 404, "Produto não encontrado.");

                return new Response<Produto>(produto, 200, "Produto encontrado.");
            }
            catch (Exception ex)
            {
                return new Response<Produto>(null, 500, $"Erro ao buscar produto: {ex.Message}");
            }
        }

        public async Task<Response<Produto>> UpdateProdutoAsync(ProdutoRequest request)
        {
            try
            {
                var produto = new Produto
                {
                    Id = request.Id,
                    Title = request.Title,
                    Description = request.Description,
                    CodigoCatalogo = request.CodigoCatalogo,
                    Image = request.Image
                };

                var produtoAtualizado = await _produtoRepository.UpdateAsync(produto);
                if (produtoAtualizado == null)
                    return new Response<Produto>(null, 404, "Produto não encontrado para atualização.");

                return new Response<Produto>(produtoAtualizado, 200, "Produto atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return new Response<Produto>(null, 500, $"Erro ao atualizar produto: {ex.Message}");
            }
        }
    }
}
