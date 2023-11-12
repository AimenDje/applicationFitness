namespace SuiviFitness.Models
{
    public class DetailSeance
    {
        public int IDDetailSeance { get; set; }
        public int IDSéance { get; set; }
        public int IDExercice { get; set; }
        public int NombreSeries { get; set; }
        public int RepetitionsParSerie { get; set; }
        public int PoidsUtilise { get; set; }

        // Autres attributs pertinents
        // ...

        // Relation avec la séance d'entraînement
        public Seance SeanceEntrainement { get; set; }

        // Relation avec l'exercice
        public Exercice Exercice { get; set; }
    }
}
