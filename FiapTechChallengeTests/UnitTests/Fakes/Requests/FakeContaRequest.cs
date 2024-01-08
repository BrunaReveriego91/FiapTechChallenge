using Bogus;
using Bogus.Extensions.Brazil;
using FiapTechChallenge.API.DTO;

namespace FiapTechChallenge.API.Tests.UnitTests.Fakes.Requests
{
    public static class FakeContaRequest
    {
        public static ContaDTO? Get()
        {
            return GetList(1).FirstOrDefault();
        }

        public static List<ContaDTO> GetList(int qtdeRegistros = 1)
        {
            var contaFaker = new Faker<ContaDTO>("pt_BR")
                .RuleFor(c => c.NumeroConta, f => f.Random.Number(1, 9999))
                .RuleFor(c => c.CPF, f => f.Person.Cpf().Replace(".", "").Replace("-", ""))
                .RuleFor(c => c.Nome, f => f.Person.FullName)
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.NomeMae, f => f.Person.FullName)
                .RuleFor(c => c.NomePai, f => f.Person.FullName)
                .RuleFor(c => c.Renda, f => f.Random.Decimal(1000, 5000))
                .RuleFor(c => c.CEP, f => f.Address.ZipCode())
                .RuleFor(c => c.Logradouro, f => f.Address.StreetName())
                .RuleFor(c => c.Numero, f => f.Random.Number(1, 100))
                .RuleFor(c => c.Complemento, f => f.Address.SecondaryAddress())
                .RuleFor(c => c.Bairro, f => f.Address.City())
                .RuleFor(c => c.Cidade, f => f.Address.City())
                .RuleFor(c => c.Estado, f => f.Address.StateAbbr())
                .RuleFor(c => c.Ativo, f => f.Random.Bool())
                .RuleFor(c => c.Senha, f => f.Internet.Password())
                .RuleFor(c => c.DadosBancarios, new List<DadosBancariosDTO>()
                {
                    new Faker<DadosBancariosDTO>("pt_BR")
                        .RuleFor(b=> b.CodigoBanco , b=> b.Random.Number(1,100).ToString())
                        .RuleFor(b=> b.Agencia , b=> b.Random.Number(1,100).ToString())
                        .RuleFor(b=> b.NumeroConta , b=> b.Random.Number(1,100).ToString())

                });

            var conta = contaFaker.Generate(qtdeRegistros);
            return conta;
        }
    }
}
