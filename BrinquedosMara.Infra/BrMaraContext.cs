using BrinquedosMara.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BrinquedosMara.Repository
{
        /// <summary>
        /// Contexto principal da aplicação que representa a conexão com o banco de dados.
        /// </summary>
        public class BrMaraContext : DbContext
        {
            public BrMaraContext(DbContextOptions<BrMaraContext> options)
                : base(options)
            {
            }

            /// <summary>
            /// Tabela de produtos.
            /// </summary>
            public DbSet<Produto> Produto { get; set; } = null!;

            /// <summary>
            /// Configuração das entidades via Fluent API.
            /// </summary>
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                modelBuilder.Entity<Produto>();
            }
        }
    }
