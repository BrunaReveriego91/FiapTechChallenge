﻿namespace FiapTechChallenge.API.Entity
{
    public class Ordem : Entidade
    {
        public Ordem()
        {
        }

        public string Simbolo { get; set; }
        public string Nome { get; set; }
        public string TipoOrdem { get; set; }

    }
}
