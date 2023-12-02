using System.Text.Json.Serialization;

namespace FiapTechChallenge.API.Entity
{
    public class ClasseInvestimento : Entidade
    {
        public ClasseInvestimento()
        {
     
        }

        public string Descricao { get; set; }

        [JsonIgnore]
        public ICollection<Investimento> Investimentos { get; set; }
    }
}
