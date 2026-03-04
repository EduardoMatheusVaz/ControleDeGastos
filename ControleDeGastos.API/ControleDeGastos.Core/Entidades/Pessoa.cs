namespace ControleDeGastos.Core.Entidades
{
    public sealed class Pessoa
    {
        public Pessoa()
        {
                
        }

        public Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        public int IdPessoa { get; private set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }

        public List<Transacao> Transacoes { get; }

        public Pessoa AtualizaPessoa(Pessoa pessoa, string nome, int idade)
        {
            pessoa.Nome = nome;
            pessoa.Idade = idade;

            return pessoa;
        }
    }
}
