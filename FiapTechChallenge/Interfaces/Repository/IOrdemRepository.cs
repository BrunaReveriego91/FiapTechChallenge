using FiapTechChallenge.API.Entity;

namespace FiapTechChallenge.API.Interfaces.Repository
{
    public interface IOrdemRepository
    {
        Ordem CadastrarOrdem(string tipoOrdem, int quantidade);

        Task<List<Ordem>> ListarOrdens();
    }
}
