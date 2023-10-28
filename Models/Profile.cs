namespace SuiviFitness.Models
{
    public class Profile
    {
        public string? description { get; set; }
        public List<string>? preferenceAlimentaire { get; set; } // "Végétarien" ou "Carnivor" ou "Mixte"
        public List<string>? niveauDeFitness { get; set; } // "Débutant" ou "Intermédiaire" ou "Avancé"
    }
}
