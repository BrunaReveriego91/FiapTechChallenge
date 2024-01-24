using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using FiapTechChallenge.API.Services;
using FiapTechChallenge.API.Tests.UnitTests.Fakes;
using FiapTechChallenge.API.Tests.UnitTests.Fakes.Requests;
using FluentValidation;
using FluentValidation.Results;
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

        [Fact]
        public async Task AdicionarConta_DeveRetornarSucesso_DeveRetornarConta()
        {

            //Arrange
            var servico = CriarServico();

            var contaFakerRequest = FakeContaRequest.Get();

            var listaDadosBancarios = new List<DadosBancario>();

            foreach (var item in contaFakerRequest.DadosBancarios)
            {
                listaDadosBancarios.Add(new DadosBancario
                {
                    CodigoBanco = item.CodigoBanco,
                    Agencia = item.Agencia,
                    NumeroConta = item.NumeroConta,
                });
            };

            var contaFake = new Conta()
            {
                Usuario = new Usuario()
                {
                    Nome = contaFakerRequest.Nome,
                    Email = contaFakerRequest.Email,
                    Login = contaFakerRequest.NumeroConta.ToString(),
                    Senha = contaFakerRequest.Senha
                },

                NumeroConta = contaFakerRequest.NumeroConta,
                CPF = contaFakerRequest.CPF,
                Nome = contaFakerRequest.Nome,
                Email = contaFakerRequest.Email,
                NomeMae = contaFakerRequest.NomeMae,
                NomePai = contaFakerRequest.NomePai,
                Renda = contaFakerRequest.Renda,
                CEP = contaFakerRequest.CEP,
                Logradouro = contaFakerRequest.Logradouro,
                Numero = contaFakerRequest.Numero,
                Complemento = contaFakerRequest.Complemento,
                Bairro = contaFakerRequest.Bairro,
                Cidade = contaFakerRequest.Cidade,
                Estado = contaFakerRequest.Estado,
                DadosBancarios = listaDadosBancarios

            };


            _validator.Setup(x => x.Validate(It.IsAny<Conta>())).Returns(new ValidationResult());
            _contaRepository.Setup(x => x.AdicionarConta(It.IsAny<Conta>())).Returns(contaFake);

            //Act
            var response = servico.AdicionarConta(contaFakerRequest);

            //Assert
            Assert.NotNull(response);

        }

        [Fact]
        public async Task AdicionarConta_DeveRetornarFalha_DeveRetornarValidationException()
        {

            //Arrange
            var servico = CriarServico();

            var contaFakerRequest = FakeContaRequest.Get();

            var listaDadosBancarios = new List<DadosBancario>();

            foreach (var item in contaFakerRequest.DadosBancarios)
            {
                listaDadosBancarios.Add(new DadosBancario
                {
                    CodigoBanco = item.CodigoBanco,
                    Agencia = item.Agencia,
                    NumeroConta = item.NumeroConta,
                });
            };

            var contaFake = new Conta()
            {
                Usuario = new Usuario()
                {
                    Nome = contaFakerRequest.Nome,
                    Email = contaFakerRequest.Email,
                    Login = contaFakerRequest.NumeroConta.ToString(),
                    Senha = contaFakerRequest.Senha
                },

                NumeroConta = contaFakerRequest.NumeroConta,
                CPF = contaFakerRequest.CPF,
                Nome = contaFakerRequest.Nome,
                Email = contaFakerRequest.Email,
                NomeMae = contaFakerRequest.NomeMae,
                NomePai = contaFakerRequest.NomePai,
                Renda = contaFakerRequest.Renda,
                CEP = contaFakerRequest.CEP,
                Logradouro = contaFakerRequest.Logradouro,
                Numero = contaFakerRequest.Numero,
                Complemento = contaFakerRequest.Complemento,
                Bairro = contaFakerRequest.Bairro,
                Cidade = contaFakerRequest.Cidade,
                Estado = contaFakerRequest.Estado,
                DadosBancarios = listaDadosBancarios

            };


            _validator.Setup(x => x.Validate(It.IsAny<Conta>())).Returns(new ValidationResult() { Errors = new List<ValidationFailure>() { new ValidationFailure("PropertyName", "Mensagem de erro") } });
            _contaRepository.Setup(x => x.AdicionarConta(It.IsAny<Conta>())).Returns(contaFake);

            //Act
            var serviceException = Assert.Throws<ValidationException>(() => servico.AdicionarConta(contaFakerRequest));


            //Assert
            Assert.NotNull(serviceException);

        }


    }
}
