using BrinquedosMara.Domain.Repository.BrinquedosMara.Domain.Repository;
using BrinquedosMara.Domain.Service;
using BrinquedosMara.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrinquedosMara.Service.Extentions
{
    /// <summary>
    /// Classe estática responsável por registrar as dependências
    /// da camada de serviço e repositórios.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Registra os Serviços e Repositorios utilizados.
        /// </summary>
        public static IServiceCollection AddProdutoScoped(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            
            return services;
        }
    }
}
