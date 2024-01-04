namespace FiapTechChallenge.API.Entity
{
    public class Ordem : Entidade
    {
        public Ordem()
        {
        }

        public string TipoOrdem { get; set; } = string.Empty;
        public int Quantidade { get; set; } = 0;
    }
}
