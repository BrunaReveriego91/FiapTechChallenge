using FiapTechChallenge.Consumidor.DTO;
using FiapTechChallenge.Consumidor.Entity;
using FiapTechChallenge.Consumidor.Interfaces.Repository;
using FiapTechChallenge.Consumidor.Interfaces.Services;

namespace FiapTechChallenge.Consumidor.Services
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
