using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace FiapTechChallenge.API.Repository
{
    public class OrdemRepository : EFRepository<Ordem>, IOrdemRepository
    {
        public OrdemRepository(ApplicationDbContext context) : base(context)
        {
        }
        public Ordem CadastrarOrdem(OrdemStore data)
        {
            Ordem ordemCadastrada = new Ordem { 
                Nome = data.Nome,
                Simbolo = data.Simbolo,
                TipoOrdem = data.TipoOrdem
            };

            _context.Ordem.Add(ordemCadastrada);
            _context.SaveChanges();
            return ordemCadastrada;
        }

        public async Task<List<Ordem>> ListarOrdens()
        {
            return await _context.Ordem.ToListAsync();
        }
    }
}
