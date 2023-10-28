namespace SuiviFitness.Models
{
    public class Nourriture
    {
        public string? nom { get; set; }
        public List<string>? categoriesNouriture { get; set; } // "Viandes" ou "Legumes" ou "Fruits" ou "Boissons"
        public double? calories { get; set; }
        public double? proteines { get; set; }
        public double? glucides { get; set; }
        public double? lipides { get; set; }
        public double? fibres { get; set; }
        public double? matiereGrasses { get; set; }
        public List<string>? tailleDePortion { get; set; } // "En grammes" ou "En portions standard" ou "En cuillères" 
    }
}
