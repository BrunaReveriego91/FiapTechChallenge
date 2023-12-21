using Bogus;
using FiapTechChallenge.API.Entity;

namespace FiapTechChallenge.API.Tests.UnitTests.Fakes
{
    public static class FakeUsuario
    {
        public static Usuario? Get()
        {
            return GetList(1).FirstOrDefault();
        }

        public static List<Usuario> GetList(int qtdeRegistros = 1)
        {
            var usuarioFaker = new Faker<Usuario>("pt_BR")
                .RuleFor(c => c.Id, f => f.Random.Int(1, 10))
                .RuleFor(c => c.Nome, f => f.Person.FullName)
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.Login, f => f.Person.UserName)
                .RuleFor(c => c.Senha, f => f.Random.Word());


            var usuarios = usuarioFaker.Generate(qtdeRegistros);
            return usuarios;
        }
    }
}
