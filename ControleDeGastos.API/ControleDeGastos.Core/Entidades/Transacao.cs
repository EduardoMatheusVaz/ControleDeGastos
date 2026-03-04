using ControleDeGastos.Core.Enums;

namespace ControleDeGastos.Core.Entidades
{
    public sealed class Transacao
    {
        public Transacao()
        {
            
        }

        public Transacao(string descricao, int valor, TipoEnum tipoDespesa, int categoria, int idPessoa)
        {
            Descricao = descricao;
            Valor = valor;
            TipoDespesa = tipoDespesa;
            IdCategoria = categoria;
            IdPessoa = idPessoa;
        }

        public int IdTransacao { get; private set; }
        public string Descricao { get; private set; }
        public int Valor { get; }
        public TipoEnum TipoDespesa { get; private set; }
        public int IdCategoria { get; private set; }
        public int IdPessoa { get; private set; }

        public Pessoa Pessoa { get; private set; }
        public Categoria Categoria { get; private set; }
    }
}
