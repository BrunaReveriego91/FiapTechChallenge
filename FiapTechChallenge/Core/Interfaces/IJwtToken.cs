using FiapTechChallenge.API.Entity;

namespace FiapTechChallenge.API.Core.Interfaces
{
    public interface IJwtToken
    {
        public string GenerateToken(Usuario usuario);
    }
}
