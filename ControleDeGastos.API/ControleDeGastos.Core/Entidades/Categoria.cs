using ControleDeGastos.Core.Enums;

namespace ControleDeGastos.Core.Entidades
{
    public sealed class Categoria
    {
        public Categoria()
        {
            
        }

        public Categoria(string descricao, FinalidadeEnum finalidade)
        {
            Descricao = descricao;
            Finalidade = finalidade;
        }

        public int IdCategoria { get; private set; }
        public string Descricao { get; private set; }
        public FinalidadeEnum Finalidade { get; private set; }

        public List<Transacao> Transacoes { get; }
    }
}
