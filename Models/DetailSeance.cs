using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SuiviFitness.Models
{
    public class DetailSeance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDDetailSeance { get; set; }
        public int IDSéance { get; set; }
        public int IDExercice { get; set; }
        public int NombreSeries { get; set; }
        public int RepetitionsParSerie { get; set; }
        public int PoidsUtilise { get; set; }

        // Autres attributs pertinents
        // ...

        // Relation avec la séance d'entraînement
        [ForeignKey("IDSéance")]
        public Seance SeanceEntrainement { get; set; }

        // Relation avec l'exercice
        [ForeignKey("IDExercice")]
        public Exercice Exercice { get; set; }
    }
}
