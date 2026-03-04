using ControleDeGastos.Core.DTOs;
using ControleDeGastos.Core.Entidades;

namespace ControleDeGastos.Core.Interfaces.Repositories
{
    public interface IPessoasRepository
    {
        Task<int> CriaCadastroPessoa(string nome, int idade);
        Task<Pessoa> ObtemPessoaPeloId(int id);
        Task<List<Pessoa>> ObtemTodasPessoas();
        Task<bool> AtualizaPessoa(int id, string nome, int idade);
        Task<bool> DeletaPessoa(int id);
        Task<List<TotaisPessoaDto>> ObtemTotaisPorPessoa();
    }
}
