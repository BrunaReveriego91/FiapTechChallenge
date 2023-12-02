using FiapTechChallenge.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace FiapTechChallenge.API.Repository
{
    public class EFRepository<T> where T : Entidade
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
    }
}
