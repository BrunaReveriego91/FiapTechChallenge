using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace FiapTechChallenge.API.Repository
{
    public class ContaRepository : EFRepository<Conta>, IContaRepository
    {
        public ContaRepository(ApplicationDbContext context) : base(context)
        {
        }
        public Conta AdicionarConta(Conta conta)
        {
            _context.Conta.Add(conta);
            _context.SaveChanges();
            return conta;
        }

        public Conta AtualizarConta(Conta conta)
        {

            _context.Conta.Update(conta);            
            _context.SaveChanges();
            return conta;
        }
        public async Task RemoverContaAsync(Conta conta)
        {
            Conta contaDelete = await ObterContaPorId(conta.Id);
            _context.Conta.Remove(contaDelete);
            _context.SaveChanges();
        }

        public async Task<Conta> ObterContaPorId(int id)
        {
            return await _context.Conta.Include(d => d.DadosBancarios).FirstOrDefaultAsync(p => p.Id.Equals(id)); 
        }

        public async Task<Conta> ObterContaPorNumero(int numeroConta)
        {
            return await _context.Conta.Include(d => d.DadosBancarios).FirstOrDefaultAsync(p => p.NumeroConta.Equals(numeroConta));
        }

        public async Task<List<Conta>> ObterLista()
        {
            return await _context.Conta.Include(d => d.DadosBancarios).ToListAsync();
        }


    }
}
