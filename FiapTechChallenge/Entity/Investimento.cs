namespace FiapTechChallenge.API.Entity
{
    public class Investimento : Entidade
    {
        public Investimento(string descricao, int idClasseInvestimento)
        {
            Descricao = descricao;
            IdClasseInvestimento = idClasseInvestimento;
        }

        public string Descricao { get; set; }
        public int IdClasseInvestimento { get; set; }
        public ClasseInvestimento ClasseInvestimento { get; set; }

    }
}
