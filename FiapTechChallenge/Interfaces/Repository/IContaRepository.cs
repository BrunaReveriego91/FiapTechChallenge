using FiapTechChallenge.API.Entity;

namespace FiapTechChallenge.API.Interfaces.Repository
{
    public interface IContaRepository
    {
        Task<List<Conta>> ObterLista();
        Task<Conta> ObterContaPorId(int id);
        Task<Conta> ObterContaPorNumero(int numeroConta);
        Conta AdicionarConta(Conta conta);
        Conta AtualizarConta(Conta conta);
        Task RemoverContaAsync(Conta conta);
    }
}
