using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace SuiviFitness.Models
{
    public class Exercice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDExercice { get; set; }
        public string NomExercice { get; set; }
        public string Description { get; set; }
        public string TypeExercice { get; set; }

        // Autres attributs pertinents
        // ...

        // Relation avec les détails de la séance d'entraînement
        public List<DetailSeance> DetailsSeanceEntrainement { get; set; }
    }
}
