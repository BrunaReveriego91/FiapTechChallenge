﻿using FiapTechChallenge.API.Entity;

namespace FiapTechChallenge.API.Interfaces.Services
{
    public interface IInvestimentosService
    {
        Task<List<Investimento>> ObterListaInvestimentosDisponiveis();
    }
}
