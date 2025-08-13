using BrinquedosMara.Core.Models;
using BrinquedosMara.Domain.Requests;
using BrinquedosMara.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrinquedosMara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        /// <summary>
        /// Retorna todos os produtos.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAllAsync()
        {
            var produtos = await _produtoService.GetAllAsync();
            return Ok(produtos);
        }

        /// <summary>
        /// Retorna um produto pelo ID.
        /// </summary>
        [HttpGet("{id:long}", Name = "GetProdutoById")] 
        public async Task<ActionResult<Produto>> GetByIdAsync(long id)
        {
            var produto = await _produtoService.GetByIdAsync(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        /// <summary>
        /// Cria um novo produto.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Produto>> CreateProdutoAsync([FromBody] ProdutoRequest produto)
        {
            var criado = await _produtoService.CreateProdutoAsync(produto);
            if (criado.Data == null)
                return BadRequest("Falha ao criar produto.");

            // Use CreatedAtRoute com o nome que você definiu
            return CreatedAtRoute("GetProdutoById", new { id = criado.Data.Id }, criado.Data);
        }

        /// <summary>
        /// Atualiza um produto existente.
        /// </summary>
        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateProdutoAsync(long id, [FromBody] ProdutoRequest produto)
        {
            if (id != produto.Id)
                return BadRequest("O ID informado não corresponde ao produto enviado.");

            var atualizado = await _produtoService.UpdateProdutoAsync(produto);
            if (!atualizado.IsSuccess)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Remove um produto.
        /// </summary>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteProdutoAsync(long id)
        {
            var removido = await _produtoService.DeleteProdutoAsync(id);
            if (!removido.IsSuccess)
                return NotFound();

            return NoContent();
        }
    }
}
