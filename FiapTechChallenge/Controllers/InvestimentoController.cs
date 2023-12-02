﻿using FiapTechChallenge.API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FiapTechChallenge.API.Controllers
{
    [ApiController]
    [Route("Investimentos")]
    public class InvestimentoController : ControllerBase
    {
        private readonly IInvestimentosService _investimentosService;

        public InvestimentoController(IInvestimentosService investimentosService)
        {
            _investimentosService = investimentosService;
        }

        /// <summary>
        /// Obter Lista de Investimentos Disponíveis
        /// </summary>
        /// <returns>Lista de Investimentos</returns>
        [HttpGet("obter-todos-investimentos")]
        public async Task<IActionResult> ObterListaInvestimentosDisponiveis()
        {
            return Ok(await _investimentosService.ObterListaInvestimentosDisponiveis());
        }
    }
}
