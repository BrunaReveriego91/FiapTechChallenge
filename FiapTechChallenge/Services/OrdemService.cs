using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using FiapTechChallenge.API.Interfaces.Services;

namespace FiapTechChallenge.API.Services
{
    public class OrdemService : IOrdemService
    {
        private readonly IOrdemRepository _ordemRepository;

        public OrdemService(IOrdemRepository ordemRepository)
        {
            _ordemRepository = ordemRepository;
        }

        public Ordem CadastrarOrdem(string tipoOrdem, int quantidade)
        {
            return _ordemRepository.CadastrarOrdem(tipoOrdem, quantidade);            
        }

        public async Task<List<Ordem>> ListarOrdens()
        {
            return await _ordemRepository.ListarOrdens();
        }
    }
}
