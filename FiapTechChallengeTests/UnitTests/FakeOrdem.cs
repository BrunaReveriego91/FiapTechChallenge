using Bogus;
using FiapTechChallenge.API.Entity;

namespace FiapTechChallenge.API.Tests.UnitTests
{
    public class FakeOrdem
    {
        public static Ordem? Get()
        {
            return GetList(1).FirstOrDefault();
        }

        public static List<Ordem> GetList(int qtdeRegistros = 1)
        {
            var ordemFaker = new Faker<Ordem>("pt_BR")
                .RuleFor(c => c.Simbolo, f => f.Random.Word())
                .RuleFor(c => c.Nome, f => f.Random.Word())
                .RuleFor(c => c.TipoOrdem, f => f.Random.Word());
     

            var ordem = ordemFaker.Generate(qtdeRegistros);
            return ordem;
        }
    }
}
