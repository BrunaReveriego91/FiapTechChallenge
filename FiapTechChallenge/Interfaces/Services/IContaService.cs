using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;

namespace FiapTechChallenge.API.Interfaces.Services
{
    public interface IContaService
    {
        Task<List<Conta>> ObterLista();
        Task<Conta> ObterContaPorId(int id);
        Task<Conta> ObterContaPorNumero(int numeroConta);
        Conta AdicionarConta(ContaDTO conta);
        Conta AtualizarConta(ContaDTO conta);
        Task RemoverConta(int id);
    }
}
