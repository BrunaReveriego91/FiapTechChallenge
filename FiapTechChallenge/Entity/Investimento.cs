namespace FiapTechChallenge.API.Entity
{
    public class Investimento : Entidade
    {
        public Investimento()
        {

        }

        public string Descricao { get; set; }
        public int IdClasseInvestimento { get; set; }
        public ClasseInvestimento ClasseInvestimento { get; set; }

    }
}
