using FiapTechChallenge.Consumidor.DTO;
using FiapTechChallenge.Consumidor.Entity;

namespace FiapTechChallenge.Consumidor.Interfaces.Services
{
    public interface ITransacaoService
    {
        Transacao CadastrarTransacao(TransacaoStore data);

        Task<List<Transacao>> ListarTransacoes();
    }
}
