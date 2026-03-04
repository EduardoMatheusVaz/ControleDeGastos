using ControleDeGastos.Core.Entidades;
using ControleDeGastos.Core.Enums;
using ControleDeGastos.Core.Interfaces.Repositories;
using ControleDeGastos.Infraestrutura.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleDeGastos.Infraestrutura.Persistencia.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly ControleDeGastosDbContext _dbContext;
        private readonly string _connectionString;

        public TransacaoRepository(ControleDeGastosDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("ControleDeGastos");
        }

        /// <summary>
        /// Task que cadastra uma transação no banco de dados via Entity Framework
        /// Bloqueia o cadastro da transação caso o indivíduo seja menor de idade e tenha como tipo de despesa uma despesa e não uma receita
        /// </summary>
        public async Task<int> CadastraTransacao(string descricao, int valor, TipoEnum tipoDespesa, int categoria, int idPessoa)
        {
            var novaTransacao = new Transacao
                (
                    descricao: descricao, 
                    valor: valor, 
                    tipoDespesa: tipoDespesa, 
                    categoria: categoria, 
                    idPessoa: idPessoa
                );

            var pessoa = await _dbContext.Pessoas
                .FirstOrDefaultAsync(p => p.IdPessoa == novaTransacao.IdPessoa);

            if (pessoa.Idade < 18 && novaTransacao.TipoDespesa != TipoEnum.Despesa)
                throw new InvalidOperationException("Menores de 18 anos só podem cadastrar despesas");

            await _dbContext.Transacoes.AddAsync(novaTransacao);
            await _dbContext.SaveChangesAsync();

            return novaTransacao.IdTransacao;
        }

        /// <summary>
        /// Gera a query SQL para obter todas as transações cadastradas no banco de dados.
        /// A query é executada diretamente no banco.
        /// </summary>
        public async Task<List<Transacao>> ObtemTodasTransacoes()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = TransacoesQueries.ObtemTodasTransacoes();

                var consulta = await sqlConnection.QueryAsync<Transacao>(script);

                return consulta.ToList();
            }
        }

        /// <summary>
        /// Gera a query SQL para obter a transação cadastrada no banco de dados.
        /// A query é executada diretamente no banco.
        /// </summary>
        public async Task<Transacao> ObtemTransacaoPeloId(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = TransacoesQueries.ObtemTransacaoPeloId(id: id);

                var consulta = await sqlConnection.QuerySingleOrDefaultAsync<Transacao>(script);

                return consulta;
            }
        }
    }
}
