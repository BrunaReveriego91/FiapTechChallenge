using FiapTechChallenge.API.Core.Interfaces;
using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Interfaces.Repository;
using FiapTechChallenge.API.Services;
using FiapTechChallenge.API.Tests.UnitTests.Fakes;
using Moq;
using Xunit;

namespace FiapTechChallenge.API.Tests.UnitTests
{
    public class AutenticarServiceTests
    {
        Mock<IAutenticarRepository> _autenticarRepository = new Mock<IAutenticarRepository>();
        Mock<IJwtToken> _jwtToken = new Mock<IJwtToken>();

        private AutenticarService CriarServico()
        {
            return new AutenticarService(_autenticarRepository.Object, _jwtToken.Object);
        }

        [Fact]
        public async Task AutenticarUsuario_DeveRetornarSucesso()
        {
            //Arrange
            var servico = CriarServico();
            var usuarioFaker = FakeUsuario.Get();

            _autenticarRepository.Setup(x => x.Autenticar(It.IsAny<UsuarioLogin>())).ReturnsAsync(usuarioFaker);
            //Act
            var response = await servico.Autenticar(It.IsAny<UsuarioLogin>());

            //Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task AutenticarUsuario_DeveRetornarException()
        {
            //Arrange
            var servico = CriarServico();
            var usuarioFaker = FakeUsuario.Get();

            _autenticarRepository.Setup(x => x.Autenticar(FakeUsuarioLogin.Get())).ReturnsAsync(usuarioFaker);

            //Act

            var serviceException = await Assert.ThrowsAsync<Exception>(async () => await servico.Autenticar(FakeUsuarioLogin.Get()));

            //Assert
            Assert.NotNull(serviceException);
        }
    }
}
