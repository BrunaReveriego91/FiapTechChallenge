using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;

namespace FiapTechChallenge.API.Interfaces.Services
{
    public interface IOrdemService
    {
        Ordem CadastrarOrdem(OrdemStore data);

        Task<List<Ordem>> ListarOrdens();
    }
}
