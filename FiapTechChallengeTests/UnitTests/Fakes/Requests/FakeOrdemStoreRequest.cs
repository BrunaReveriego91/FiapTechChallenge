using Bogus;
using FiapTechChallenge.API.DTO;

namespace FiapTechChallenge.API.Tests.UnitTests.Fakes.Requests
{
    public class FakeOrdemStoreRequest
    {
        public static OrdemStore? Get()
        {
            return GetList(1).FirstOrDefault();
        }

        public static List<OrdemStore> GetList(int qtdeRegistros = 1)
        {
            var ordemFaker = new Faker<OrdemStore>("pt_BR")
                .RuleFor(c => c.Simbolo, f => f.Random.Word())
                .RuleFor(c => c.Nome, f => f.Random.Word())
                .RuleFor(c => c.TipoOrdem, f => f.Random.Word());


            var ordem = ordemFaker.Generate(qtdeRegistros);
            return ordem;
        }
    }
}
