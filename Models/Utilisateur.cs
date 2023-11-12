using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuiviFitness.Models
{
    public class Utilisateur
    {
        public int IDUtilisateur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string AdresseEmail { get; set; }
        public string MotDePasseHash { get; set; }
        public string TypeUtilisateur { get; set; }

        // Propriétés spécifiques au type d'utilisateur (certifications pour les coachs, par exemple)
        public string Certifications { get; set; }

        // Relation avec les séances d'entraînement
        public List<Seance> SeancesEntrainement { get; set; }
    }

}
