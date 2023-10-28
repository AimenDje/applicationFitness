namespace SuiviFitness.Models
{
    public class SuivieDonneesNutritionnel
    {
        public List<Nourriture>? nourrituresConsomee { get; set; }
        public int? apportCalorique { get; set; }
        public List<string>? valeursNutritives  { get; set; }
    }
}
