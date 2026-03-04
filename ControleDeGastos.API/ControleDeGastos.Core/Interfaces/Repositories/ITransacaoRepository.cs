using ControleDeGastos.Core.Entidades;
using ControleDeGastos.Core.Enums;

namespace ControleDeGastos.Core.Interfaces.Repositories
{
    public interface ITransacaoRepository
    {
        Task<int> CadastraTransacao(string descricao, int valor, TipoEnum tipoDespesa, int categoria, int idPessoa);
        Task<Transacao> ObtemTransacaoPeloId(int id);
        Task<List<Transacao>> ObtemTodasTransacoes();
    }
}
