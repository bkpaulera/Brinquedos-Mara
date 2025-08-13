using BrinquedosMara.Repository;
using BrinquedosMara.Service.Extentions;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BrinquedosMara.API.Common
{
    public static class BuilderExtensions
    {
        public static void AddAppConfiguration(this WebApplicationBuilder builder)
        {
            // Configuração de DbContext
            builder.Services.AddDbContext<BrMaraContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Configuração de JSON
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });
        }

        public static void AddAppServices(this WebApplicationBuilder builder)
        {
            // Registro dos serviços da camada Service
            builder.Services.AddProdutoScoped();
            // Aqui você pode adicionar outros AddXScoped() de outros módulos
        }

        public static void AddSwaggerDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
    }
}
