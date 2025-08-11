using BrinquedosMara.Core.Models;
using BrinquedosMara.Domain.Repository.BrinquedosMara.Domain.Repository;
using BrinquedosMara.Repository;
using Microsoft.EntityFrameworkCore;

namespace BrinquedosMara.Infra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly BrMaraContext _context;

        public ProdutoRepository(BrMaraContext context)
        {
            _context = context;
        }

        public async Task<Produto> CreateAsync(Produto produto)
        {
            await _context.Produto.AddAsync(produto);
            await _context.SaveChangesAsync();
            
            return produto;
        }

        public async Task<Produto?> GetByIdAsync(long id)
        {
            return await _context.Produto.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var produto = await _context.Produto.FirstOrDefaultAsync(x => x.Id == id);

            if (produto == null)
                return false;

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<IList<Produto>> GetAllAsync()
        {
            return await _context.Produto
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<Produto?> UpdateAsync(Produto produto)
        {
            var produtoEncontrado = await _context.Produto.FirstOrDefaultAsync(x => x.Id == produto.Id);

            if (produtoEncontrado == null)
                return null;

            produtoEncontrado.Title = produto.Title;
            produtoEncontrado.Description = produto.Description;
            produtoEncontrado.Image = produto.Image;
            produtoEncontrado.CodigoCatalogo = produto.CodigoCatalogo;

            _context.Produto.Update(produtoEncontrado);
            await _context.SaveChangesAsync();

            return produtoEncontrado;
        }
    }
}
