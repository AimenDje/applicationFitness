using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuiviFitness.Models
{
    public class Objectif
    {
        public List<string> objectifDeFitness { get; set; } // "Perte de poids" ou "Prise de masse Musculaire"
        public double? poidsCible { get; set; }
        public Date? dateLimite { get; set; }
    }
}
