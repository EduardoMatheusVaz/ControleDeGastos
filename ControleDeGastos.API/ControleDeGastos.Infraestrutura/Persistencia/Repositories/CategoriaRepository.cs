using ControleDeGastos.Core.Entidades;
using ControleDeGastos.Core.Enums;
using ControleDeGastos.Core.Interfaces.Repositories;
using ControleDeGastos.Infraestrutura.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ControleDeGastos.Infraestrutura.Persistencia.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ControleDeGastosDbContext _dbContext;
        private readonly string _connectionString;

        public CategoriaRepository(ControleDeGastosDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("ControleDeGastos");
        }

        /// <summary>
        /// Cadastra uma nova categoria via Entity Framework
        /// </summary>
        public async Task<int> CadastraCategoria(string descricao, FinalidadeEnum finalidade)
        {
            var novaCategoria = new Categoria(descricao: descricao, finalidade: finalidade);

            await _dbContext.Categorias.AddAsync(novaCategoria);
            await _dbContext.SaveChangesAsync();

            return novaCategoria.IdCategoria;
        }

        /// <summary>
        /// Gera a query SQL para obter a categoria cadastrada no banco de dados.
        /// Retorna a categoria filtrada pelo Id
        /// </summary>
        public async Task<Categoria> ObtemCategoriaPeloId(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = CategoriaQueries.ObtemCategoriaPeloId(id: id);

                var consulta = await sqlConnection.QuerySingleOrDefaultAsync<Categoria>(script);

                return consulta;
            }
        }

        /// <summary>
        /// Gera a query SQL para obter todas as categorias cadastradas no banco de dados.
        /// A query é executada diretamente no banco.
        /// </summary>
        public async Task<List<Categoria>> ObtemTodasCategorias()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = CategoriaQueries.ObtemTodasCategorias();

                var consulta = await sqlConnection.QueryAsync<Categoria>(script);

                return consulta.ToList();
            }
        }
    }
}
