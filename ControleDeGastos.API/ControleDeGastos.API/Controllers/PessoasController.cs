using ControleDeGastos.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastos.API.Controllers
{
    [ApiController]
    [Route("api/pessoas")]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoasRepository _pessoasRepository;

        public PessoasController(IPessoasRepository pessoasRepository)
        {
            _pessoasRepository = pessoasRepository;
        }

        /// <summary>
        /// Controller responsável pelo cadastro de pessoas.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CriarCadastroPessoa(string nome, int idade)
        {
            try
            {
                var id = await _pessoasRepository.CriaCadastroPessoa(nome: nome, idade: idade);

                return CreatedAtAction(nameof(ConsultarPessoaPeloId), new { Id = id }, id);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao criar cadastro de pessoa. Retorno: {ex.Message}";

                return BadRequest(mensagem);
            }
        }

        /// <summary>
        /// Controller responsável por consultar todas as pessoas cadastradas.
        /// </summary>
        [HttpGet("todas_pessoas")]
        public async Task<IActionResult> ConsultarPessoa()
        {
            try
            {
                var retorno = await _pessoasRepository.ObtemTodasPessoas();

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao consultar pessoas. Retorno: {ex.Message}";

                return BadRequest(mensagem);
            }
        }

        /// <summary>
        /// Controller responsável por consultar os totais de todas as pessoas cadastradas.
        /// </summary>
        [HttpGet("totais_pessoas")]
        public async Task<IActionResult> ConsultaTotaisPorPessoa()
        {
            try
            {
                var retorno = await _pessoasRepository.ObtemTotaisPorPessoa();

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao consultar totais por pessoas. Retorno: {ex.Message}";

                return BadRequest(mensagem);
            }
        }

        /// <summary>
        /// Controller responsável por consultar uma pessoa filtrada pelo Id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarPessoaPeloId(int id)
        {
            try
            {
                var retorno = await _pessoasRepository.ObtemPessoaPeloId(id: id);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao pessoa pelo identificador. Retorno: {ex.Message}";

                return BadRequest(mensagem);
            }
        }

        /// <summary>
        /// Controller responsável por deletar uma pessoa filtrando pelo Id.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPessoaPeloId(int id)
        {
            try
            {
                var retorno = await _pessoasRepository.DeletaPessoa(id: id);

                if (!retorno)
                    return BadRequest(retorno);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao deletar cadastro de pessoa. Retorno: {ex.Message}";

                return BadRequest(mensagem);
            }
        }

        /// <summary>
        /// Controller responsável por atualizar uma pessoa pelo Id.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPessoaPeloId(int id, string nome, int idade)
        {
            try
            {
                var retorno = await _pessoasRepository.AtualizaPessoa(id: id, nome: nome, idade: idade);

                if (!retorno)
                    return BadRequest(retorno);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao atualizar cadastro de pessoa. Retorno: {ex.Message}";

                return BadRequest(mensagem);
            }
        }
    }
}
