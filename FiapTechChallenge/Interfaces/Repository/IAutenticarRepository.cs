using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;

namespace FiapTechChallenge.API.Interfaces.Repository
{
    public interface IAutenticarRepository
    {
        Task<Usuario> Autenticar(UsuarioLogin usuarioLogin);
    }
}
