using FiapTechChallenge.API.Entity;

namespace FiapTechChallenge.API.Interfaces.Services
{
    public interface IOrdemService
    {
        Ordem CadastrarOrdem(string tipoOrdem, int quantidade);

        Task<List<Ordem>> ListarOrdens();
    }
}
