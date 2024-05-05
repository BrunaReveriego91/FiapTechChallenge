using FiapTechChallenge.API.DTO;

namespace FiapTechChallenge.API.Interfaces.RabbitMQ
{
    public interface IOrdensRabbitMQ
    {
        void cadastrarOrdem(OrdemStore data);
    }
}
