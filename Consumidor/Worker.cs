using FiapTechChallenge.Consumidor.DTO;
using FiapTechChallenge.Consumidor.Interfaces.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Consumidor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly ITransacaoService _transacaoService;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, ITransacaoService transacaoService)
        {
            _logger = logger;
            _configuration = configuration;
            _transacaoService = transacaoService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                string rabbitMQHost = _configuration["RabbitMQ:host"];
                string rabbitMQUser = _configuration["RabbitMQ:user"];
                string rabbitMQPassword = _configuration["RabbitMQ:senha"];

                var factory = new ConnectionFactory()
                {
                    HostName = rabbitMQHost,
                    UserName = rabbitMQUser,
                    Password = rabbitMQPassword
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

                    var consumer = new EventingBasicConsumer( channel );

                    consumer.Received += (sender, evetArgs) =>
                    {
                        var body = evetArgs.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        var pedido = JsonSerializer.Deserialize<TransacaoStore>(message);
                        Console.WriteLine($"Quantidade: {pedido.Quantidade}, PrecoCompra: {pedido.PrecoCompra}, TipoTransacao: {pedido.TipoTransacao}, {pedido.Status}");
                        // var data = _transacaoService.CadastrarTransacao(pedido);
                    };

                    channel.BasicConsume(
                        queue: "fila",
                        autoAck: false,
                        consumer: consumer
                    );
                }
            }
            await Task.Delay(2000, stoppingToken);
        }
    }
}