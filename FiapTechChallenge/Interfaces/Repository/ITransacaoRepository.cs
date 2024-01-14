using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;

namespace FiapTechChallenge.API.Interfaces.Repository
{
    public interface ITransacaoRepository
    {
        Transacao CadastrarTransacao(TransacaoStore data);

        Task<List<Transacao>> ListarTransacoes();
    }
}
