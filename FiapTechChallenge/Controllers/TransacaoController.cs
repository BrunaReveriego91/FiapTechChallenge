using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace FiapTechChallenge.API.Controllers
{
    [ApiController]
    [Route("/transacao")]
    public class TransacaoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TransacaoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Store([FromBody] TransacaoStore modelo)
        {
            return Ok(User.Identity.Name);

            string rabbitMQHost = _configuration["RabbitMQ:host"];
            string rabbitMQUser = _configuration["RabbitMQ:user"];
            string rabbitMQPassword = _configuration["RabbitMQ:senha"];

            var transacao = new TransacaoStoreRabbitMQ
            {
                AtivoSimbolo = modelo.AtivoSimbolo,
                Quantidade = modelo.Quantidade,
                PrecoCompra = modelo.PrecoCompra,
                TipoTransacao = TipoTransacao.Compra,
                DataTransacao = DateTime.UtcNow,
                UsuarioId = 1,
            };

            var factory = new ConnectionFactory()
            {
                HostName = rabbitMQHost,
                UserName = rabbitMQUser,
                Password = rabbitMQPassword,
            };

            using var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: "fila",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                var message = JsonSerializer.Serialize(transacao);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: "fila",
                    basicProperties: null,
                    body: body
                );
            }
            return Ok();
        }
    }
}
