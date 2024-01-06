namespace FiapTechChallenge.API.Entity
{
    public class Usuario : Entidade
    {
        public Usuario()
        {

        }        
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public int IdConta { get; set; }
        public Conta Conta { get; set; }
    }
}
