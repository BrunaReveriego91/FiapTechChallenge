using FiapTechChallenge.API.DTO;
using FiapTechChallenge.API.Entity;
using FiapTechChallenge.API.Interfaces.Repository;
using FiapTechChallenge.API.Interfaces.Services;

namespace FiapTechChallenge.API.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _repository;

        public ContaService(IContaRepository repository)
        {
            _repository = repository;
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
            conta.Usuario = new List<Usuario>
            {
                usuario
            };
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

            return _repository.AdicionarConta(conta);
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
            return _repository.AtualizarConta(conta);
        }
        public Task RemoverConta(int id)
        {
            var conta = _repository.ObterContaPorId(id).Result;

            if (conta == null) { throw new Exception("Conta não encontrada"); }

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
