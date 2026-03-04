using ControleDeGastos.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeGastos.Infraestrutura.Configuracoes
{
    public class CategoriasConfiguracoes : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder
                .ToTable("tb_Categoria")
                .HasKey(i => i.IdCategoria);

            builder
                .Property(d => d.Descricao)
                .IsRequired(true)
                .HasColumnType("VARCHAR(400)");

            builder
                .Property(d => d.Finalidade)
                .IsRequired(true);
        }
    }
}
