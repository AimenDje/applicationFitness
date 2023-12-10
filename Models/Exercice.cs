using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace SuiviFitness.Models
{
    public class Exercice
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdExercice { get; set; }

        [Required(ErrorMessage = "Le nom de l'exercice est obligatoire")]
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [Display(Name = "Nom")]
        public string? nom { get; set; }


        [Required(ErrorMessage = "L'aliment est obligatoire")]
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        [Display(Name = "Aliment")]
        public string? aliment { get; set; }


        [Required(ErrorMessage = "Les calories sont obligatoires obligatoire")]
        [Display(Name = "Calories")]
        public int ? calories { get; set; }


        [Required(ErrorMessage = "La date de l'exercice est obligatoire.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date de l'exercice")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? date { get; set; }


        [Required(ErrorMessage = "La durée  est obligatoire")]
        [Display(Name = "Photo")]
        public string? photo { get; set; }


      


        [ForeignKey("ObjectifId")]
        public int ObjectifId { get; set; }
        public Objectif? Objectif { get; set; }





    }
}
