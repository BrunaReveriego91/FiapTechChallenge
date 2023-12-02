using FiapTechChallenge.API.Entity;

namespace FiapTechChallenge.API.Interfaces.Repository
{
    public interface IInvestimentoRepository
    {
        Task<List<Investimento>> ObterListaInvestimentosDisponiveis();
    }
}
