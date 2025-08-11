using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrinquedosMara.Domain.Requests
{
    public class ProdutoRequest 
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Título inválido")]
        [MaxLength(80, ErrorMessage = "O título deve conter até 80 caracteres")]
        public string Title { get; set; } = string.Empty;
        public string CodigoCatalogo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Image { get; set; }
    }
}
