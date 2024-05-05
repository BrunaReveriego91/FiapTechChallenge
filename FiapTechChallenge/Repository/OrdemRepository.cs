using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FiapTechChallenge.API.Repository
{
    public class OrdemRepository : EFRepository<Ordem>, IOrdemRepository
    {
        private readonly IConnection _connection;
        public OrdemRepository(ApplicationDbContext context, IConnection connection) : base(context)
        {
            _connection = connection;
        }
        public Ordem CadastrarOrdem(OrdemStore data)
        {
            Ordem ordemCadastrada = new Ordem { 
                Nome = data.Nome,
                Simbolo = data.Simbolo,
                TipoOrdem = data.TipoOrdem
            };

            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: "ordens",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var ordem = JsonSerializer.Deserialize<Ordem>(message);

                    _context.Ordem.Add(ordem);
                    _context.SaveChanges();
                };

                channel.BasicConsume(queue: "pedidos",
                                     autoAck: true,
                                     consumer: consumer);
            }

            return ordemCadastrada;
        }

        public async Task<List<Ordem>> ListarOrdens()
        {
            return await _context.Ordem.ToListAsync();
        }
    }
}
