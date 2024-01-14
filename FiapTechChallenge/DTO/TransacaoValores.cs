using FiapTechChallenge.API.Enums;

namespace FiapTechChallenge.API.DTO
{
    public class TransacaoValores
    {
        public int Quantidade { get; set; }
        public decimal PrecoCompra { get; set; }
        public int UsuarioId { get; set; }
        public int OrdemId { get; set; }
    }
}
