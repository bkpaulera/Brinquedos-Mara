using BrinquedosMara.Core.Models;
using BrinquedosMara.Domain.Requests;
using BrinquedosMara.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrinquedosMara.Domain.Service
{
    public interface IProdutoService
    {
        Task<Response<Produto>> CreateProdutoAsync (ProdutoRequest produto);
        Task<Response<Produto>> UpdateProdutoAsync (ProdutoRequest produto);
        Task<Response<bool>> DeleteProdutoAsync(long id);
        Task<Response<Produto>> GetByIdAsync (long id);
        Task<Response<IList<Produto>>> GetAllAsync ();
    }
}
