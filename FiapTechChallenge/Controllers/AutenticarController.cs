using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapTechChallenge.API.Controllers
{
    [ApiController]
    [Route("Autenticar")]
    public class AutenticarController : ControllerBase
    {
        private readonly IAutenticarService _autenticarService;
        public AutenticarController(IAutenticarService autenticarService)
        {
            _autenticarService = autenticarService; 
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Autenticado))]
        [Produces("application/json")]
        [HttpPost()]
        [AllowAnonymous]
        public async Task<IActionResult> Autenticar(UsuarioLogin usuarioLogin)
        {
            var autenticado = await _autenticarService.Autenticar(usuarioLogin);
            return Ok(autenticado);
        }
    }
}
