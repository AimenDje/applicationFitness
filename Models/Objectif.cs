using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuiviFitness.Models
{
    public class Objectif
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ObjectifId { get; set; }
        [Required(ErrorMessage = "L'objectif de l'exercice est obligatoire.")]
        
        public string Nom { get; set; }
        public virtual ICollection<Exercice> Exercices { get; set; }
    }
}
