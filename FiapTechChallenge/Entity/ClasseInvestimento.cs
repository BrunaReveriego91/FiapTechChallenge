namespace FiapTechChallenge.API.Entity
{
    public class ClasseInvestimento : Entidade
    {
        public string Descricao { get; set; }
        public ICollection<Investimento> Investimentos { get; set; }
    }
}
