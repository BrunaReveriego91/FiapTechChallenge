using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapTechChallenge.API.Controllers
{
    [ApiController]
    [Route("Conta")]
    public class ContaController : Controller
    {

        private readonly IContaService _contaService;
        private readonly ILogger<ContaController> _logger;

        public ContaController(IContaService contaService, ILogger<ContaController> logger)
        {
            _contaService = contaService;
            _logger = logger;
        }

        /// <summary>
        /// Obter Lista de Contas Disponíveis
        /// </summary>
        /// <returns>Lista de Contas</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Conta>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [HttpGet("obter-todos")]
        [Authorize]
        public async Task<IActionResult> ObterListaConta()
        {
            return Ok(await _contaService.ObterLista());
        }
        /// <summary>
        /// Obter Conta por id
        /// </summary>
        /// <returns>Conta</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Conta))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [HttpGet("obter-conta-id/{id:int}")]
        [Authorize]
        public async Task<IActionResult> ObterContaId(int id)
        {
            return Ok(await _contaService.ObterContaPorId(id));
        }
        /// <summary>
        /// Obter Conta por numero da conta
        /// </summary>
        /// <returns>Conta</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Conta))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [HttpGet("obter-conta-numero/{numero:int}")]
        [Authorize]
        public async Task<IActionResult> ObterContaNumero(int numero)
        {
            return Ok(await _contaService.ObterContaPorNumero(numero));
        }
        /// <summary>
        /// Cadastrar Conta
        /// </summary>
        /// <returns>Conta</returns>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Conta))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [HttpPost("adiciona-conta")]
        //[Authorize]
        public IActionResult Adicionar(ContaDTO conta)
        {
            try
            {
                _logger.LogInformation($"Adicionando conta {conta.CPF}");
                return StatusCode(StatusCodes.Status201Created, _contaService.AdicionarConta(conta));
            }
            catch (ValidationException ex)
            {
                _logger.LogError(ex, "Error ao Adicionar conta");
                return StatusCode(400, new { error = ex.Message });
            }
            catch
            {
                _logger.LogCritical("Adicionar conta - Falha interna no servidor");
                return StatusCode(500, "Falha interna no servidor");
            }
        }
        /// <summary>
        /// Atualizar Conta
        /// </summary>
        /// <returns>Conta</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Conta))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [HttpPut("atualiza-conta")]
        [Authorize]
        public IActionResult Atualiza(ContaDTO conta)
        {
            try
            {
                _logger.LogInformation($"Atualizando conta {conta.CPF}");
                return Ok(_contaService.AtualizarConta(conta));
            }
            catch (ValidationException ex)
            {
                _logger.LogError(ex, "Error ao Atualizar conta");
                return StatusCode(400, ex.Message);
            }
            catch
            {
                _logger.LogCritical("Atualizar conta - Falha interna no servidor");
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        /// <summary>
        /// Atualizar Conta
        /// </summary>
        /// <returns>Conta</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Conta))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [HttpDelete("remover-conta/{id:int}")]
        //[Authorize]
        public IActionResult Remove(int id)
        {
            try
            {
                _logger.LogInformation($"Atualizando conta {id}");
                return Ok(_contaService.RemoverConta(id));
            }
            catch (ValidationException ex)
            {
                _logger.LogError(ex, "Error ao Remover conta");
                return StatusCode(400, ex.Message);
            }
            catch
            {
                _logger.LogCritical("Remover conta - Falha interna no servidor");
                return StatusCode(500, "Falha interna no servidor");
            }
            
        }
    }

}
