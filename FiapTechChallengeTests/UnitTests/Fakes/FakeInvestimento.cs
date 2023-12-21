using Bogus;
using FiapTechChallenge.API.Entity;

namespace FiapTechChallenge.API.Tests.UnitTests.Fakes
{
    public static class FakeInvestimento
    {
        public static Investimento? Get()
        {
            return GetList(1).FirstOrDefault();
        }

        public static List<Investimento> GetList(int qtdeRegistros = 1)
        {
            var investimentoFaker = new Faker<Investimento>("pt_BR")
                .RuleFor(c => c.Id, f => f.Random.Int(1, 10))
                .RuleFor(c => c.Descricao, "Tesouro Direto")
                .RuleFor(c => c.IdClasseInvestimento, f => f.Random.Int(1, 10))
                .RuleFor(c => c.ClasseInvestimento, new Faker<ClasseInvestimento>("pt_BR")
                    .RuleFor(x=> x.Id, f => f.Random.Int(1,10))
                    .RuleFor(x => x.Descricao, "Renda Fixa")
                ); 
                 
            var investimentos = investimentoFaker.Generate(qtdeRegistros);
            return investimentos;
        }
    }
}
