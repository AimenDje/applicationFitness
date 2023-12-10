using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuiviFitness.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string nom { get; set; } 
        public string prenom { get; set; }
        public byte[] photoProfil { get; set; }
        public DateTime? dateDeNaissance { get; set; }
        public bool estSportif { get; set; }

    }
}
