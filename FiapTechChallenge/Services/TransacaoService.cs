using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using FiapTechChallenge.API.Interfaces.Services;

namespace FiapTechChallenge.API.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoService(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        public Transacao CadastrarTransacao(TransacaoStore data)
        {
            return _transacaoRepository.CadastrarTransacao(data);            
        }

        public async Task<List<Transacao>> ListarTransacoes()
        {
            return await _transacaoRepository.ListarTransacoes();
        }
    }
}
