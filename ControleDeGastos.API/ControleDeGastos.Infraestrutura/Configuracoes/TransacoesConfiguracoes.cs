using ControleDeGastos.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeGastos.Infraestrutura.Configuracoes
{
    public class TransacoesConfiguracoes : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder
                .ToTable("tb_Transacao")
                .HasKey(i => i.IdTransacao);

            builder
                .Property(d => d.Descricao)
                .HasColumnType("VARCHAR(400)");

            builder
                .HasOne(p => p.Pessoa)
                .WithMany(t => t.Transacoes)
                .HasForeignKey(id => id.IdPessoa);

            builder
                .HasOne(p => p.Categoria)
                .WithMany(t => t.Transacoes)
                .HasForeignKey(id => id.IdCategoria);

            builder
                .Property(d => d.Valor)
                .IsRequired(true);

            builder
                .Property(d => d.TipoDespesa)
                .IsRequired(true);
        }
    }
}
