using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrinquedosMara.Core.Models
{
    /// <summary>
    /// Representa um produto disponível no catálogo da aplicação.
    /// Contém informações básicas como título, descrição e imagem.
    /// </summary>
    public class Produto
    {
        
        /// <summary>
        /// Identificador único do produto. 
        /// Chave primária no banco de dados.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Código único do catálogo
        /// </summary>
        public string CodigoCatalogo { get; set; } = string.Empty;

        /// <summary>
        /// Título do produto.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Descrição do produto.
        /// Contem detalhes como Material e Embalagem.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// URL ou caminho da imagem representando o produto.
        /// Essa imagem pode ser exibida no catálogo ou em detalhes do produto.
        /// </summary>
        public string? Image { get; set; }
    }

}
