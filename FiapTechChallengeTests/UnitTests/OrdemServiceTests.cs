using FiapTechChallenge.API.Interfaces.Repository;
using FiapTechChallenge.API.Services;
using FiapTechChallenge.API.Tests.UnitTests.Fakes.Requests;
using Moq;
using Xunit;

namespace FiapTechChallenge.API.Tests.UnitTests
{
    public class OrdemServiceTests
    {
        Mock<IOrdemRepository> _ordemRepository = new Mock<IOrdemRepository>();
        private OrdemService CriarServico()
        {
            return new OrdemService(_ordemRepository.Object);
        }

        [Fact]
        public async Task CadastrarOrdem_DeveRetornarOrdem()
        {
            await Task.Run(() =>
            {
                //Arrange
                var servico = CriarServico();

                var ordemStoreFaker = FakeOrdemStoreRequest.Get();
                var ordemFaker = FakeOrdem.Get();

                _ordemRepository.Setup(x => x.CadastrarOrdem(ordemStoreFaker)).Returns(ordemFaker);
                //Act
                var response = servico.CadastrarOrdem(ordemStoreFaker);

                //Assert
                Assert.NotNull(response);

            });
        }


        [Fact]
        public async Task ObterListOrdens_DeveRetornarListaOrdens()
        {
            //Arrange
            var servico = CriarServico();
            var ordemFaker = FakeOrdem.GetList(1);

            _ordemRepository.Setup(x => x.ListarOrdens()).ReturnsAsync(ordemFaker);
            //Act
            var response = await servico.ListarOrdens();

            //Assert
            Assert.NotNull(response);
        }
    }
}
