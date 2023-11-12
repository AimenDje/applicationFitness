using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuiviFitness.Models
{
    public class Seance
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDSeance { get; set; }
        public int IDUtilisateur { get; set; }
        public DateTime DateHeure { get; set; }
        public string Description { get; set; }

        // Relation avec l'utilisateur
        [ForeignKey("IDUtilisateur")]
        public Utilisateur Utilisateur { get; set; }



    }
}
