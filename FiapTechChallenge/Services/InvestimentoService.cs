using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using FiapTechChallenge.API.Interfaces.Services;

namespace FiapTechChallenge.API.Services
{

    public class InvestimentoService : IInvestimentosService
    {
        private readonly IInvestimentoRepository _repository;

        public InvestimentoService(IInvestimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Investimento>> ObterListaInvestimentosDisponiveis()
        {
            return await _repository.ObterListaInvestimentosDisponiveis();
        }
    }
}
