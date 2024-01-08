using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using FiapTechChallenge.API.Repository;
using FiapTechChallenge.API.Services;
using FiapTechChallenge.API.Tests.UnitTests.Fakes;
using FiapTechChallenge.API.Tests.UnitTests.Fakes.Requests;
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


    }
}
