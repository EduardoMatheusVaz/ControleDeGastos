using ControleDeGastos.Core.DTOs;
using ControleDeGastos.Core.Entidades;
using ControleDeGastos.Core.Interfaces.Repositories;
using ControleDeGastos.Infraestrutura.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleDeGastos.Infraestrutura.Persistencia.Repositories
{
    public class PessoaRepository : IPessoasRepository
    {
        private readonly ControleDeGastosDbContext _dbContext;
        private readonly string _connectionString;

        public PessoaRepository(ControleDeGastosDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("ControleDeGastos");
        }

        /// <summary>
        /// Recebe os parametros
        /// Ao localizar o usuário no banco, é chamado o método da entidade que faz a atualização das propriedades
        /// Após o método da entidade o usuário é atualizado no banco
        /// </summary>
        public async Task<bool> AtualizaPessoa(int id, string nome, int idade)
        {
            var pessoa = await _dbContext.Pessoas
                .FirstOrDefaultAsync(x => x.IdPessoa == id);

            if (pessoa is null)
                return false;

            pessoa.AtualizaPessoa(pessoa: pessoa, nome: nome, idade: idade);

            var retorno = await _dbContext.SaveChangesAsync();

            if (retorno > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Cadastra uma nova pessoa no banco de dados via Entity Framework
        /// </summary>
        public async Task<int> CriaCadastroPessoa(string nome, int idade)
        {
            var novaPessoa = new Pessoa(nome: nome, idade: idade);

            await _dbContext.Pessoas.AddAsync(novaPessoa);
            await _dbContext.SaveChangesAsync();

            return novaPessoa.IdPessoa;
        }

        /// <summary>
        /// Deleta uma pessoa cadastrada no banco de dados
        /// Ao remover a pessoa, todas as transações referentes a ela também são removidas
        /// </summary>
        public async Task<bool> DeletaPessoa(int id)
        {
            var pessoa = await _dbContext.Pessoas.FirstOrDefaultAsync(x => x.IdPessoa == id);

            if (pessoa is null)
                return false;

            var transacoes = await _dbContext.Transacoes
                .Where(x => x.IdPessoa == id)
                .ToListAsync();

            _dbContext.Pessoas.Remove(pessoa);
            _dbContext.Transacoes.RemoveRange(transacoes);

            var retorno = await _dbContext.SaveChangesAsync();

            if (retorno > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Gera a query SQL para obter a pessoa filtrada pelo Id no banco de dados.
        /// A query é executada diretamente no banco.
        /// </summary>
        public async Task<Pessoa> ObtemPessoaPeloId(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = PessoasQueries.ObtemPessoaPeloId(id: id);

                var consulta = await sqlConnection.QuerySingleOrDefaultAsync<Pessoa>(script);

                return consulta;
            }
        }

        /// <summary>
        /// Gera a query SQL para obter todas as pessoas cadastradas no banco de dados.
        /// A query é executada diretamente no banco.
        /// </summary>
        public async Task<List<Pessoa>> ObtemTodasPessoas()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = PessoasQueries.ObtemTodasPessoas();

                var consulta = await sqlConnection.QueryAsync<Pessoa>(script);

                return consulta.ToList();
            }
        }

        /// <summary>
        /// Gera a query SQL para obter os totais por pessoas no banco de dados.
        /// A query é executada diretamente no banco.
        /// </summary>
        public async Task<List<TotaisPessoaDto>> ObtemTotaisPorPessoa()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = PessoasQueries.ObtemTotaisPorPessoa();

                var consulta = await sqlConnection.QueryAsync<TotaisPessoaDto>(script);

                return consulta.ToList();
            }
        }
    }
}
