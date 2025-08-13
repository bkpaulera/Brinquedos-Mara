using BrinquedosMara.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BrinquedosMara.Infra
{
    /// <summary>
    /// Fábrica usada pelo EF Core em tempo de design para criar o DbContext.
    /// </summary>
    public class BrMaraContextFactory : IDesignTimeDbContextFactory<BrMaraContext>
    {
        public BrMaraContext CreateDbContext(string[] args)
        {
            // Caminho da pasta onde está o appsettings.json da API
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "BrinquedosMara");

            // Carrega configuração a partir do appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BrMaraContext>();

            // Usa a connection string "DefaultConnection" da API
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada no appsettings.json da API.");
            }

            optionsBuilder.UseSqlServer(connectionString);

            return new BrMaraContext(optionsBuilder.Options);
        }
    }
}
