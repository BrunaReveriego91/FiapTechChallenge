using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapTechChallenge.API.Controllers
{
    [ApiController]
    [Route("Ordens")]
    public class OrdensController : ControllerBase
    {
        private readonly IOrdemService _ordemService;

        public OrdensController(IOrdemService ordemService)
        {
            _ordemService = ordemService;
        }

        /// <summary>
        /// Registra uma nova ordem no banco de dados.
        /// </summary>
        /// <param name="data">Objeto contendo os dados da ordem a ser cadastrada. São eles: Simbolo, Nome, TipoOrdem todos do tipo string </param>
        /// <returns>
        /// Retorna uma resposta de sucesso (HTTP 200 OK) caso a ordem seja cadastrada com sucesso.
        /// Retorna uma resposta de erro (HTTP 500 Internal Server Error) em caso de falha no processamento.
        /// </returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrdemStore))]
        [Produces("application/json")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CadastrarOrdem([FromBody] OrdemStore data)
        {
            try
            {
                _ordemService.CadastrarOrdem(data);
                return Ok("Ordem cadastrada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar ao cadastrar nova ordem.");
            }

        }
        /// <summary>
        /// Obtém a lista de todas as ordens cadastradas.
        /// </summary>
        /// <returns>
        /// Retorna uma resposta de sucesso (HTTP 200 OK) contendo a lista de ordens.
        /// A lista é composta por objetos JSON, cada um representando uma ordem com os campos: 
        /// - Simbolo (símbolo da ordem),
        /// - Nome (nome da ordem),
        /// - TipoOrdem (tipo de ordem),
        /// - Id (identificador único da ordem).
        /// </returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Ordem>))]
        [Produces("application/json")]
        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> ListarOrdens()
        {
            return Ok(await _ordemService.ListarOrdens());
        }
    }
}
