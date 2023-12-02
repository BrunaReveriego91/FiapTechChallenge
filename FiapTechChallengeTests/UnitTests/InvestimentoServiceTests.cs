using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using FiapTechChallenge.API.Services;
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

            var listaInvestimentosMoq = new List<Investimento>
            {
                new Investimento
                {
                    Id = 1,
                    Descricao = "Tesouro Direto",
                    IdClasseInvestimento = 1,
                    ClasseInvestimento = new ClasseInvestimento{ Id = 1, Descricao = "Renda Fixa"}
                }
            };


            _investimentoRepository.Setup(x => x.ObterListaInvestimentosDisponiveis()).ReturnsAsync(listaInvestimentosMoq);
            //Act
            var response = await servico.ObterListaInvestimentosDisponiveis();

            //Assert
            Assert.NotNull(response);
        }

    }
}
