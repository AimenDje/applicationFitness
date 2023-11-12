using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SuiviFitness.Models
{
    public class RecommendationFitness
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDRecommandation { get; set; }
        public int IDUtilisateur { get; set; }
        public DateTime DateRecommandation { get; set; }
        public string TypeRecommandation { get; set; }
        public string ContenuRecommandation { get; set; }

        // Relation avec l'utilisateur
        [ForeignKey("IDUtilisateur")]
        public Utilisateur Utilisateur { get; set; }
    }
}
