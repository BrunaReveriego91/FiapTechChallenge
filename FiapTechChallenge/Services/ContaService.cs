using FiapTechChallenge.API.Core.Helpers;
using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using FiapTechChallenge.API.Interfaces.Services;
using FluentValidation;

namespace FiapTechChallenge.API.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _repository;
        private readonly IValidator<Conta> _validator;

        public ContaService(IContaRepository repository,
                           IValidator<Conta> validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public Conta AdicionarConta(ContaDTO contaDto)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = contaDto.Nome;
            usuario.Email = contaDto.Email;
            usuario.Login = contaDto.NumeroConta.ToString();
            usuario.Senha = contaDto.Senha;
            Conta conta = new Conta();
            conta.NumeroConta = contaDto.NumeroConta;
            conta.CPF = contaDto.CPF;
            conta.Nome = contaDto.Nome;
            conta.Email = contaDto.Email;
            conta.NomeMae = contaDto.NomeMae;
            conta.NomePai = contaDto.NomePai;
            conta.Renda = contaDto.Renda;
            conta.CEP = contaDto.CEP;
            conta.Logradouro = contaDto.Logradouro;
            conta.Numero = contaDto.Numero;
            conta.Complemento = contaDto.Complemento;
            conta.Bairro = contaDto.Bairro;
            conta.Cidade = contaDto.Cidade;
            conta.Estado = contaDto.Estado;
            conta.Usuario = usuario;
            conta.DadosBancarios = new List<DadosBancario>();
            foreach (var item in contaDto.DadosBancarios)
            {
                conta.DadosBancarios.Add(new DadosBancario
                {
                    CodigoBanco = item.CodigoBanco,
                    Agencia = item.Agencia,
                    NumeroConta = item.NumeroConta,
                });
            };

            var validationResult = _validator.Validate(conta);

            if (validationResult.IsValid)
            {
                return _repository.AdicionarConta(conta);
            }
            else
            {
                throw new ValidationException(validationResult.Errors.Concat(","));
            }
        }

        public Conta AtualizarConta(ContaDTO contaDto)
        {
            Conta conta = _repository.ObterContaPorNumero(contaDto.NumeroConta).Result;
            conta.NumeroConta = contaDto.NumeroConta;
            conta.CPF = contaDto.CPF;
            conta.Nome = contaDto.Nome;
            conta.Email = contaDto.Email;
            conta.NomeMae = contaDto.NomeMae;
            conta.NomePai = contaDto.NomePai;
            conta.Renda = contaDto.Renda;
            conta.CEP = contaDto.CEP;
            conta.Logradouro = contaDto.Logradouro;
            conta.Numero = contaDto.Numero;
            conta.Complemento = contaDto.Complemento;
            conta.Bairro = contaDto.Bairro;
            conta.Cidade = contaDto.Cidade;
            conta.Estado = contaDto.Estado;
            conta.DadosBancarios = new List<DadosBancario>();
            foreach (var item in contaDto.DadosBancarios)
            {
                conta.DadosBancarios.Add(new DadosBancario
                {
                    CodigoBanco = item.CodigoBanco,
                    Agencia = item.Agencia,
                    NumeroConta = item.NumeroConta,
                });
            };

            var validationResult = _validator.Validate(conta);

            if (validationResult.IsValid)
            {
                return _repository.AtualizarConta(conta);
            }
            else
            {
                throw new ValidationException(validationResult.Errors.Concat(","));
            }
        }
        public Task RemoverConta(int id)
        {
            var conta = _repository.ObterContaPorId(id).Result;

            if (conta == null) { throw new ValidationException("Conta não encontrada"); }

            conta.Ativo = false;

            _repository.AtualizarConta(conta);
            return Task.CompletedTask;
        }

        public Task<Conta> ObterContaPorId(int id)
        {
            return _repository.ObterContaPorId(id);
        }

        public Task<Conta> ObterContaPorNumero(int numeroConta)
        {
            return _repository.ObterContaPorNumero(numeroConta);
        }

        public Task<List<Conta>> ObterLista()
        {
            return _repository.ObterLista();
        }


    }
}
