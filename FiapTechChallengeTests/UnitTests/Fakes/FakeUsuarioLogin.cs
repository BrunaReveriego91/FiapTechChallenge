using Bogus;
using FiapTechChallenge.API.DTO;

namespace FiapTechChallenge.API.Tests.UnitTests.Fakes
{
    public static class FakeUsuarioLogin
    {
        public static UsuarioLogin Get()
        {
            var usuarioLoginFaker = new Faker<UsuarioLogin>("pt_BR")
                .RuleFor(c => c.Login, f => f.Person.UserName)
                .RuleFor(c => c.Password, f=> f.Random.Word());

            var usuarioLogin = usuarioLoginFaker.Generate();
            return usuarioLogin;
        }
    }
}
