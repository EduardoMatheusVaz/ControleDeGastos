 using ControleDeGastos.Core.Entidades;
using ControleDeGastos.Core.Enums;

namespace ControleDeGastos.Core.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        Task<int> CadastraCategoria(string descricao, FinalidadeEnum finalidade);
        Task<Categoria> ObtemCategoriaPeloId(int id);
        Task<List<Categoria>> ObtemTodasCategorias();
    }
}
