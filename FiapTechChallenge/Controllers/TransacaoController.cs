using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Enums;
using FiapTechChallenge.API.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace FiapTechChallenge.API.Controllers
{
    [ApiController]
    [Route("/Transacao")]
    public class TransacaoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(IConfiguration configuration, ITransacaoService transacaoService)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _transacaoService = transacaoService ?? throw new ArgumentNullException(nameof(transacaoService));
        }
        /// <summary>
        /// Registra uma nova transação no sistema.
        /// </summary>
        /// <remarks>
        /// Este endpoint permite o registro de uma nova transação (do tipo compra), enviando os dados necessários para processamento.
        /// Os dados incluem a quantidade, preço de compra, ID do usuário e ID da ordem.
        /// Após o registro, a transação é enfileirada em um sistema de mensagens (RabbitMQ) para processamento assíncrono.
        /// </remarks>
        /// <param name="modelo">Dados da transação a serem registrados.</param>
        /// <returns>
        /// Retorna uma resposta de sucesso (HTTP 200 OK) após o registro da transação.
        /// </returns>
        [HttpPost]
        [Produces("application/json")]
        //[Authorize]
        public IActionResult Store([FromBody] TransacaoValores modelo)
        {
            try
            {
                string rabbitMQHost = _configuration["RabbitMQ:host"];
                string rabbitMQUser = _configuration["RabbitMQ:user"];
                string rabbitMQPassword = _configuration["RabbitMQ:senha"];

                var transacao = new TransacaoStore
                {
                    Quantidade = modelo.Quantidade,
                    PrecoCompra = modelo.PrecoCompra,
                    TipoTransacao = TipoTransacao.Compra,
                    DataTransacao = DateTime.UtcNow,
                    UsuarioId = modelo.UsuarioId,
                    OrdemId = modelo.OrdemId,
                    Status = Status.Pendente
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
                return Ok("Requisição feita");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar ao cadastrar nova ordem.");
            }
        }
    }
}
