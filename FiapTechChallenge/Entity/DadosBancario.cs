namespace FiapTechChallenge.API.Entity
{
    public class DadosBancario : Entidade
    {

        public DadosBancario()
        {

        }
        public string CodigoBanco { get; set; }
        public string NumeroConta { get; set; }
        public string Agencia { get; set; }        
        public int IdConta { get; set; }
        public Conta Conta { get; set; }
    }
}
