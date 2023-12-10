using FiapTechChallenge.API.Core.Interfaces;
using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using FiapTechChallenge.API.Interfaces.Services;

namespace FiapTechChallenge.API.Services
{
    public class AutenticarService : IAutenticarService
    {
        private readonly IAutenticarRepository _autenticarRepository;
        private readonly IJwtToken _jwtToken;

        public AutenticarService(IAutenticarRepository autenticarRepository, IJwtToken jwtToken)
        {
            _autenticarRepository = autenticarRepository;
            _jwtToken = jwtToken;
        }

        public async Task<Autenticado> Autenticar(UsuarioLogin usuarioLogin)
        {

            Usuario usuario = await _autenticarRepository.Autenticar(usuarioLogin);
            if (usuario == null)
            {
                throw new Exception("Usuário ou senha inválidos");
            }
            var token = _jwtToken.GenerateToken(usuario);
            return new Autenticado { token = token };
        }
    }
}
