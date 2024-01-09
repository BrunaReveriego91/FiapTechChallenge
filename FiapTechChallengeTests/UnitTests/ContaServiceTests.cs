using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using FiapTechChallenge.API.Services;
using FiapTechChallenge.API.Tests.UnitTests.Fakes;
using FluentValidation;
using Moq;
using Xunit;

namespace FiapTechChallenge.API.Tests.UnitTests
{
    public class ContaServiceTests
    {
        Mock<IContaRepository> _contaRepository = new Mock<IContaRepository>();
        Mock<IValidator<Conta>> _validator = new Mock<IValidator<Conta>>();

        private ContaService CriarServico()
        {
            return new ContaService(_contaRepository.Object, _validator.Object);
        }

        [Fact]
        public async Task ObterListaContas_DeveRetornarListaContas()
        {
            //Arrange
            var servico = CriarServico();
            var contaFaker = FakeConta.GetList(1);


            _contaRepository.Setup(x => x.ObterLista()).ReturnsAsync(contaFaker);
            //Act
            var response = await servico.ObterLista();

            //Assert
            Assert.NotNull(response);
            Assert.IsType<List<Conta>>(response);
        }

        [Fact]
        public async Task ObterContaPorId_DeveRetornarConta()
        {
            //Arrange
            var servico = CriarServico();
            var contaFaker = FakeConta.Get();


            _contaRepository.Setup(x => x.ObterContaPorId(It.IsAny<int>())).ReturnsAsync(contaFaker);
            //Act
            var response = await servico.ObterContaPorId(It.IsAny<int>());

            //Assert
            Assert.NotNull(response);
            Assert.IsType<Conta>(response);
        }

        [Fact]
        public async Task ObterContaPorId_DeveRetornarNulo()
        {
            //Arrange
            var servico = CriarServico();
            var contaFaker = FakeConta.Get();


            _contaRepository.Setup(x => x.ObterContaPorId(It.Is<int>(id => id != 100))).ReturnsAsync((Conta)null);
            //Act
            var response = await servico.ObterContaPorId(100);

            //Assert
            Assert.Null(response);
         
        }
    }
}
