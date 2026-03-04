namespace ControleDeGastos.Core.DTOs
{
    public class TotaisPessoaDto
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public int Receitas { get; set; }
        public int Despesas { get; set; }
        public int Saldo { get; set; }
    }
}
