using FiapTechChallenge.Consumidor.Entity;
using Microsoft.EntityFrameworkCore;

namespace FiapTechChallenge.Consumidor.Repository
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
