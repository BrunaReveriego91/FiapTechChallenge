﻿
using FiapTechChallenge.API.Enums;

namespace FiapTechChallenge.API.Entity
{
    public class Transacao : Entidade
    {
        public Transacao()
        {

        }
        public int Quantidade { get; set; }
        public decimal PrecoCompra { get; set; }
        public DateTime DataTransacao { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public Status Status { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int OrdemId { get; set; }
        public Ordem Ordem { get; set; }
    }
}
