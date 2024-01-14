using FiapTechChallenge.Consumidor.DTO;
using FiapTechChallenge.Consumidor.Entity;

namespace FiapTechChallenge.Consumidor.Interfaces.Repository
{
    public interface ITransacaoRepository
    {
        Transacao CadastrarTransacao(TransacaoStore data);

        Task<List<Transacao>> ListarTransacoes();
    }
}
