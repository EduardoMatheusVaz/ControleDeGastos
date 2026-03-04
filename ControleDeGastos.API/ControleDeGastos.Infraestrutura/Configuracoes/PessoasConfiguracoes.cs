using ControleDeGastos.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeGastos.Infraestrutura.Configuracoes
{
    public class PessoasConfiguracoes : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder
                .ToTable("tb_Pessoas")
                .HasKey(a => a.IdPessoa);

            builder
                .Property(n => n.Nome)
                .IsRequired(true)
                .HasColumnType("VARCHAR(200)");

            builder
                .Property(n => n.Idade)
                .IsRequired(true);
        }
    }
}
