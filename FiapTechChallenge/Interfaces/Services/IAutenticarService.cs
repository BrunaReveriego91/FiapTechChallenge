using FiapTechChallenge.API.DTO;

namespace FiapTechChallenge.API.Interfaces.Services
{
    public interface IAutenticarService
    {
        Task<Autenticado> Autenticar(UsuarioLogin usuarioLogin);
    }
}