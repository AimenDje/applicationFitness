using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuiviFitness.Models
{
    public class Progression
    {
        public int IDProgression { get; set; }
        public int IDUtilisateur { get; set; }
        public DateTime Date { get; set; }
        public string TypeProgression { get; set; }
        public string DetailsProgression { get; set; }

        // Relation avec l'utilisateur
        public Utilisateur Utilisateur { get; set; }
    }
}
