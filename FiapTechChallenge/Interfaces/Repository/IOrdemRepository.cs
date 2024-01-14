using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;

namespace FiapTechChallenge.API.Interfaces.Repository
{
    public interface IOrdemRepository
    {
        Ordem CadastrarOrdem(OrdemStore data);

        Task<List<Ordem>> ListarOrdens();
    }
}
