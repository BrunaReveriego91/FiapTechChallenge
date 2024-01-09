using FiapTechChallenge.API.Enums;

namespace FiapTechChallenge.API.DTO
{
    public class TransacaoStore
    {
        public string AtivoSimbolo { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoCompra { get; set; }
    }
}
