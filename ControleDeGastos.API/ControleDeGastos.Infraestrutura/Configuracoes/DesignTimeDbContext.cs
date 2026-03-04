using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ControleDeGastos.Infraestrutura.Configuracoes
{
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<ControleDeGastosDbContext>
    {
        public ControleDeGastosDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ControleDeGastosDbContext>();
            optionsBuilder.UseSqlServer("Server=LAPTOP-BPQKIBEO\\SQLSERVER2022;Database=ControleDeGastos;User Id=sa;Password=Mortadela1!;TrustServerCertificate=True");

            return new ControleDeGastosDbContext(optionsBuilder.Options);
        }
    }
}
