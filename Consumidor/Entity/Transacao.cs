
using FiapTechChallenge.Consumidor.Enums;

namespace FiapTechChallenge.Consumidor.Entity
{
    public class Transacao : Entidade
    {
        public Transacao()
        {

        }
        public int Quantidade { get; set; }
        public decimal PrecoCompra { get; set; }
        public DateTime DataTransacao { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public Status Status { get; set; }
        public int UsuarioId { get; set; }
        public int OrdemId { get; set; }
    }
}
