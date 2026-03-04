namespace ControleDeGastos.Infraestrutura.Queries
{
    public class PessoasQueries
    {
        public static string ObtemPessoaPeloId(int id)
        {
            return $@"
                    SELECT * FROM tb_Pessoas
                    WHERE IdPessoa = {id};
            ";
        }

        public static string ObtemTodasPessoas()
        {
            return $@"
                    SELECT * FROM  tb_Pessoas;
            ";
        }

        public static string ObtemTotaisPorPessoa()
        {
            return $@"
                SELECT 
                    p.IdPessoa,
                    p.Nome,
                    ISNULL(SUM(CASE WHEN t.TipoDespesa = 0 THEN t.Valor END), 0) AS TotalReceitas,
                    ISNULL(SUM(CASE WHEN t.TipoDespesa = 1 THEN t.Valor END), 0) AS TotalDespesas,
                    ISNULL(SUM(CASE WHEN t.TipoDespesa = 0 THEN t.Valor END), 0) 
                    - ISNULL(SUM(CASE WHEN t.TipoDespesa = 1 THEN t.Valor END), 0) AS Saldo
                FROM tb_Pessoas p
                LEFT JOIN tb_Transacao t ON t.IdPessoa = p.IdPessoa
                GROUP BY p.IdPessoa, p.Nome

                UNION ALL

                -- Total geral de todas as pessoas
                SELECT 
                    0 AS IdPessoa,
                    'TOTAL GERAL' AS Nome,
                    ISNULL(SUM(CASE WHEN t.TipoDespesa = 0 THEN t.Valor END), 0) AS TotalReceitas,
                    ISNULL(SUM(CASE WHEN t.TipoDespesa = 1 THEN t.Valor END), 0) AS TotalDespesas,
                    ISNULL(SUM(CASE WHEN t.TipoDespesa = 0 THEN t.Valor END), 0) 
                    - ISNULL(SUM(CASE WHEN t.TipoDespesa = 1 THEN t.Valor END), 0) AS Saldo
                FROM tb_Transacao t;
            ";
        }
    }
}
