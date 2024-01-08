﻿using FiapTechChallenge.API.Entity;

namespace FiapTechChallenge.API.DTO
{
    public class ContaDTO
    {
        public int NumeroConta { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public Decimal Renda { get; set; } = 0;
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public bool Ativo { get; set; } = true;
        public string Senha { get; set; }        
        public List<DadosBancariosDTO> DadosBancarios { get; set; }
    }
}
