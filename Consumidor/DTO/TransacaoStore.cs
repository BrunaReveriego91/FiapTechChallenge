using FiapTechChallenge.Consumidor.Enums;

namespace FiapTechChallenge.Consumidor.DTO
{
    public class TransacaoStore
    {
        public int Quantidade { get; set; }
        public decimal PrecoCompra { get; set; }
        public DateTime DataTransacao { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public int UsuarioId { get; set; }
        public int OrdemId { get; set; }
        public Status Status { get; set; }
    }
}
