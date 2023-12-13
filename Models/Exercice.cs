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

        [Required(ErrorMessage = "Le nom de l'exercice est obligatoire.")]
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        [Display(Name = "Nom de l'exercice")]
        public string NomExercice { get; set; }

        [Required(ErrorMessage = "Une description de l'exercice est obligatoire.")]
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Description de l'exercice")]
        [MaxLength(6000, ErrorMessage = "La description ne doit pas dépasser 6000 caractères.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "La photo est obligatoire.")]
        [Display(Name = "Photo")]
        public string? Photo { get; set; }
        public int ObjectifId { get; set; }
        public virtual Objectif? Objectif { get; set; }


    }
}
