using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace FiapTechChallenge.API.Repository
{
    public class AutenticarRepository : EFRepository<Usuario>, IAutenticarRepository
    {
        public AutenticarRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Usuario> Autenticar(UsuarioLogin usuarioLogin)
        {
            try
            {
                return await _context.Usuario.FirstOrDefaultAsync(u => u.Login.Equals(usuarioLogin.Login) && u.Senha.Equals(usuarioLogin.Password));
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
