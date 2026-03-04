namespace ControleDeGastos.Infraestrutura.Queries
{
    public class TransacoesQueries
    {
        public static string ObtemTodasTransacoes()
        {
            return $@"
                    SELECT * FROM tb_Transacao;
            ";
        }

        public static string ObtemTransacaoPeloId(int id)
        {
            return $@"
                    SELECT * FROM tb_Transacao
                    WHERE IdTransacao = {id};
            ";
        }
    }
}
