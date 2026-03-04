using ControleDeGastos.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ControleDeGastos.Infraestrutura
{
    public class ControleDeGastosDbContext : DbContext
    {
        public ControleDeGastosDbContext(DbContextOptions<ControleDeGastosDbContext> options) : base(options)
        {
                
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelBuilder model = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
