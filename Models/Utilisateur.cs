using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuiviFitness.Models
{
    public class Utilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDUtilisateur { get; set; }
        public string? nom { get; set; }
        public string? prenom { get; set; }
        public string? adresseEmail { get; set; }
        public string? motDePasseHash { get; set; }
        public string? typeUtilisateur { get; set; }

        // Propriétés spécifiques au type d'utilisateur (certifications pour les coachs, par exemple)
        public string? certifications { get; set; }

        // Relation avec les séances d'entraînement
        [ForeignKey("IDSeance")]
        public List<Seance> SeancesEntrainements { get; set; }
    }

}
