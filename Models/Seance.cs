using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuiviFitness.Models
{
    public class Seance
    {
        public Date? date { get; set; }
        public int? Durée { get; set; }
        public List<string>? typeExercice { get; set; } // "Musculation" ou "Cardio" ou "Perte de poids"
        public int? nombreDeRepetitions { get; set; }
        public int? nombreDeSeries { get; set; }
        public string? commentaires { get; set; }


    }
}
