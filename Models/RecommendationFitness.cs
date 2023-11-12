namespace SuiviFitness.Models
{
    public class RecommendationFitness
    {
        public int IDRecommandation { get; set; }
        public int IDUtilisateur { get; set; }
        public DateTime DateRecommandation { get; set; }
        public string TypeRecommandation { get; set; }
        public string ContenuRecommandation { get; set; }

        // Relation avec l'utilisateur
        public Utilisateur Utilisateur { get; set; }
    }
}
