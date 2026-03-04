using ControleDeGastos.Core.Enums;
using ControleDeGastos.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastos.API.Controllers
{
    [ApiController]
    [Route("api/categorias")]

    public class CategoriasControllers : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriasControllers(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        /// <summary>
        /// Controller responsável pelo cadastro de categorias.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CadastraCategoria(string descricao, FinalidadeEnum finalidade)
        {
            try
            {
                var id = await _categoriaRepository.CadastraCategoria(descricao: descricao, finalidade: finalidade);

                return CreatedAtAction(nameof(ConsultaCategoria), new { Id = id } , id);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao cadastrar categoria. Retorno: {ex.Message}";

                return BadRequest(mensagem);
            }
        }

        /// <summary>
        /// Controller responsável por consultar todas as categorias.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ConsultaTodasCategoria()
        {
            try
            {
                var categorias = await _categoriaRepository.ObtemTodasCategorias();

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao consultar todas categoria. Retorno: {ex.Message}";

                return BadRequest(mensagem);
            }
        }

        /// <summary>
        /// Controller responsável por consultar uma categoria filtando pelo Id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaCategoria(int id)
        {
            try
            {
                var categoria = await _categoriaRepository.ObtemCategoriaPeloId(id: id);

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao consultar categoria. Retorno: {ex.Message}";

                return BadRequest(mensagem);
            }
        }
    }
}
