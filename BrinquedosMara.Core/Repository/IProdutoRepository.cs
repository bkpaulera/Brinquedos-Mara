using BrinquedosMara.Core.Models;
using BrinquedosMara.Domain.Requests;
using BrinquedosMara.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrinquedosMara.Domain.Repository
{

    namespace BrinquedosMara.Domain.Repository
    {
        /// <summary>
        /// Interface para operações de persistência relacionadas à entidade Produto.
        /// </summary>
        public interface IProdutoRepository
        {
            /// <summary>
            /// Cria um novo produto no banco de dados.
            /// </summary>
            /// <param name="produto">Entidade produto a ser criada.</param>
            /// <returns>O produto criado.</returns>
            Task<Produto> CreateAsync(Produto produto);

            /// <summary>
            /// Atualiza um produto existente.
            /// </summary>
            /// <param name="produto">Produto com os dados atualizados.</param>
            /// <returns>O produto atualizado.</returns>
            Task<Produto> UpdateAsync(Produto produto);

            /// <summary>
            /// Remove um produto do banco de dados.
            /// </summary>
            /// <param name="id">ID do produto a ser removido.</param>
            /// <returns>True se a remoção for bem-sucedida, false caso contrário.</returns>
            Task<bool> DeleteAsync(long id);

            /// <summary>
            /// Obtém um produto pelo seu ID.
            /// </summary>
            /// <param name="id">ID do produto.</param>
            /// <returns>O produto encontrado ou null se não existir.</returns>
            Task<Produto?> GetByIdAsync(long id);

            /// <summary>
            /// Retorna todos os produtos cadastrados.
            /// </summary>
            /// <returns>Lista de todos os produtos.</returns>
            Task<IList<Produto>> GetAllAsync();
        }
    }

}
