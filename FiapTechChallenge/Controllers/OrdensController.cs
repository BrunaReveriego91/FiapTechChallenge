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

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ordem))]
        [Produces("application/json")]
        [HttpPost("cadastrar-ordem")]
        [Authorize]
        public async Task<IActionResult> CadastrarOrdem(string tipoOrdem, int quantidade)
        {
            return Ok(_ordemService.CadastrarOrdem(tipoOrdem, quantidade));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Ordem>))]
        [Produces("application/json")]
        [HttpGet("listar-ordens")]
        [Authorize]
        public async Task<IActionResult> ListarOrdens()
        {
            return Ok(await _ordemService.ListarOrdens());
        }
    }
}
