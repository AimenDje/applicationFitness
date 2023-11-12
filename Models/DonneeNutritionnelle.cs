using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SuiviFitness.Models
{
    public class DonneeNutritionnelle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDDonneeNutritionnelle { get; set; }
        public int IDUtilisateur { get; set; }
        public DateTime Date { get; set; }
        public string TypeRepas { get; set; }
        public string AlimentsConsommes { get; set; }

        // Informations nutritionnelles
        public int Calories { get; set; }
        public int Proteines { get; set; }
        public int Glucides { get; set; }

        // Relation avec l'utilisateur
        [ForeignKey("IDUtilisateur")]
        public Utilisateur Utilisateur { get; set; }
    }
}
