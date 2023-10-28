using System.Drawing;

namespace SuiviFitness.Models
{
    public class Exercice
    {
        public string? nom { get; set; }
        public string? description { get; set; }
        public Image? image { get; set; }
        public List<string>? categoriesExercices { get; set; } //"Entraînement en hypertrophie" ou "Entraînement en cardio" ou "Étirements"
    }
}
