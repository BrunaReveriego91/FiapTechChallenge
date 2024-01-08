using FiapTechChallenge.API.Enums;

namespace FiapTechChallenge.API.DTO
{
    public class TransacaoStoreRabbitMQ
    {
        public string AtivoSimbolo { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoCompra { get; set; }
        public DateTime DataTransacao { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public int UsuarioId { get; set; }

    }
}
