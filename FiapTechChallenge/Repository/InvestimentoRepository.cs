using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace FiapTechChallenge.API.Repository
{
    public class InvestimentoRepository : EFRepository<Investimento>, IInvestimentoRepository
    {
        public InvestimentoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Investimento>> ObterListaInvestimentosDisponiveis()
        {
            return await _context.Investimento.Include(c => c.ClasseInvestimento).ToListAsync();

        }
    }
}
