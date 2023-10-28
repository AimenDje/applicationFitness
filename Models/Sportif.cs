using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuiviFitness.Models
{
    public class Sportif
    {
        public string? nom { get; set; }
        public string? prenom { get; set; }
        public string? email { get; set; }
        public string? motDePasse { get; set; }
        public Date? dateDeNaissance { get; set; }
        public float? taille { get; set; }
        public Image? image { get; set; }
        public List<string>? objectifDeFitness { get; set; }
    }
}
