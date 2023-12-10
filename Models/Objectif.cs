using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuiviFitness.Models
{
    public class Objectif
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdObjectif { get; set; }
        [Required(ErrorMessage = "Le nom de l'objectif est obligatoire")]
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        [Display(Name = "Nom")]
        public string nom { get; set; }

        [Required(ErrorMessage = "La progression de l'objectif est obligatoire")]
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        [Display(Name = "Progression")]

        public int? progression { get; set; }




        [ForeignKey("ExerciceId")]
        public int ExerciceId { get; set; }
        public List<Exercice>? Exercices { get; set; }


    }
}
