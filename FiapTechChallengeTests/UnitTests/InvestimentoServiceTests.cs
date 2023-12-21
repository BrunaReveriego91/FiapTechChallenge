using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using FiapTechChallenge.API.Services;
using FiapTechChallenge.API.Tests.UnitTests.Fakes;
using Moq;
using Xunit;

namespace FiapTechChallenge.API.Tests.UnitTests
{
    public class InvestimentoServiceTests
    {
        Mock<IInvestimentoRepository> _investimentoRepository = new Mock<IInvestimentoRepository>();

        private InvestimentoService CriarServico()
        {
            return new InvestimentoService(_investimentoRepository.Object);
        }

        [Fact]
        public async Task ObterListaInvestimentosDisponiveis_DeveRetornarListaInvestimentos()
        {
            //Arrange
            var servico = CriarServico();

            var investimentosFaker = FakeInvestimento.GetList(1);

            _investimentoRepository.Setup(x => x.ObterListaInvestimentosDisponiveis()).ReturnsAsync(investimentosFaker);
            //Act
            var response = await servico.ObterListaInvestimentosDisponiveis();

            //Assert
            Assert.NotNull(response);
        }

    }
}
