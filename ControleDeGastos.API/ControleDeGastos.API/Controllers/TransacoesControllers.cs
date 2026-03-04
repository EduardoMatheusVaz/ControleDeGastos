using ControleDeGastos.Core.Enums;
using ControleDeGastos.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastos.API.Controllers
{
    [ApiController]
    [Route("api/transacoes")]

    public class TransacoesControllers : ControllerBase
    {
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacoesControllers(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        /// <summary>
        /// Controller responsável pelo cadastro de transações.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CadastraTransacao(string descricao, int valor, TipoEnum tipoDespesa, int categoria, int idPessoa)
        {
            try
            {
                var id = await _transacaoRepository.CadastraTransacao
                    (
                        descricao: descricao, 
                        valor: valor, 
                        tipoDespesa: tipoDespesa, 
                        categoria: categoria, 
                        idPessoa: idPessoa
                    );

                return CreatedAtAction(nameof(ConsultaTransacaoPeloId), new { Id = id }, id);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao cadastrar transação. Retorno: {ex.Message}";

                return BadRequest(mensagem);
            }
        }

        /// <summary>
        /// Controller responsável por consultar todas as transações.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ConsultaTransacoes()
        {
            try
            {
                var transacoes = await _transacaoRepository.ObtemTodasTransacoes();

                return Ok(transacoes);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao consultar transações. Retorno: {ex.Message}";

                return BadRequest(mensagem);
            }
        }

        /// <summary>
        /// Controller responsável por consultar uma transação filtrando pelo Id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaTransacaoPeloId(int id)
        {
            try
            {
                var transacao = await _transacaoRepository.ObtemTransacaoPeloId(id: id);

                return Ok(transacao);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao consultar transações. Retorno: {ex.Message}";

                return BadRequest(mensagem);
            }
        }
    }
}
