using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Interfaces.RabbitMQ;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace FiapTechChallenge.API.Services.RabbitMQ
{
    public class OrdensRabbitMQ : IOrdensRabbitMQ
    {
        private readonly IConfiguration _configuration;
        public OrdensRabbitMQ(IConfiguration configuration)
        { 
            _configuration = configuration;
        }

        public void cadastrarOrdem(OrdemStore data)
        {
            string rabbitMQHost = _configuration["RabbitMQ:host"];
            string rabbitMQUser = _configuration["RabbitMQ:user"];
            string rabbitMQPassword = _configuration["RabbitMQ:senha"];

            var factory = new ConnectionFactory()
            {
                HostName = rabbitMQHost,
                UserName = rabbitMQUser,
                Password = rabbitMQPassword,
            };

            using var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "ordens",
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data));
                channel.BasicPublish(exchange: "",
                            routingKey: "ordens",
                            basicProperties: null,
                            body: body);
            }
        }
    }
}
