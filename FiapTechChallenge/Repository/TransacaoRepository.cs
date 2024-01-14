using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace FiapTechChallenge.API.Repository
{
    public class TransacaoRepository : EFRepository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(ApplicationDbContext context) : base(context)
        {
        }
        public Transacao CadastrarTransacao(TransacaoStore data)
        {
            Transacao transacaoCadastrada = new Transacao {
                DataTransacao = data.DataTransacao,
                PrecoCompra = data.PrecoCompra,
                Quantidade = data.Quantidade,
                TipoTransacao = data.TipoTransacao,
                UsuarioId = data.UsuarioId,
                OrdemId = data.OrdemId,
                Status = data.Status
            };
            _context.Transacao.Add(transacaoCadastrada);
            _context.SaveChanges();
            return transacaoCadastrada;
        }

        public async Task<List<Transacao>> ListarTransacoes()
        {
            return await _context.Transacao.ToListAsync();
        }
    }
}
