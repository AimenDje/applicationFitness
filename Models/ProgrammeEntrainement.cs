namespace SuiviFitness.Models
{
    public class ProgrammeEntrainement
    {
        public string? nom { get; set; }
        public string? description { get; set; }
        public List<Exercice>? listeExercice { get; set; }
        public int? dureeTotal { get; set; }
        public List<string>? niveauDeDifficulte { get; set; } // "Débutant" ou "Intermédiaire" ou "Avancé"
    }
}
