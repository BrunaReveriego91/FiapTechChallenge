using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Enums;
using FiapTechChallenge.API.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
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
        private readonly ILogger<TransacaoController> _logger;

        public TransacaoController(IConfiguration configuration, ITransacaoService transacaoService, ILogger<TransacaoController> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _transacaoService = transacaoService ?? throw new ArgumentNullException(nameof(transacaoService));
            _logger = logger;
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
        /// Retorna uma resposta de erro (HTTP 500 Internal Server Error) em caso de falha no processamento.
        /// </returns>
        [HttpPost]
        [Produces("application/json")]
        [Authorize]
        public IActionResult Store([FromBody] TransacaoValores modelo)
        {
            try
            {
                _logger.LogInformation("Fazendo a conexão com o RabbitMQ, para salvar a transação");

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
                _logger.LogError($"Error: {ex.Message}");
                Console.WriteLine($"Erro: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar ao cadastrar nova ordem.");
            }
        }
        /// <summary>
        /// Obtém a lista de transações registradas no sistema com detalhes de usuário e ordem.
        /// </summary>
        /// <remarks>
        /// Este endpoint retorna uma lista de transações registradas no sistema, incluindo informações detalhadas sobre o usuário e a ordem associados a cada transação.
        /// </remarks>
        /// <returns>
        /// Retorna uma resposta de sucesso (HTTP 200 OK) com a lista de transações e detalhes de usuário e ordem.
        /// </returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Transacao>))]
        [Produces("application/json")]
        [HttpGet("")]
        //[Authorize]
        public async Task<IActionResult> ListarTransacoes()
        {
            _logger.LogInformation("Trazendo todas as transações");

            return Ok(await _transacaoService.ListarTransacoes());
        }
    }
}
