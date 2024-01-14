using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;

namespace FiapTechChallenge.API.Interfaces.Services
{
    public interface ITransacaoService
    {
        Transacao CadastrarTransacao(TransacaoStore data);

        Task<List<Transacao>> ListarTransacoes();
    }
}
