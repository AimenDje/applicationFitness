using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuiviFitness.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Exercice> Exercices { get; set; }

        public DbSet<Objectif> Objectif { get; set; }

        public void SeedData()
        {
            // Obtenez la liste de blogs avec des données préremplies
            var SampleObjectifs = TestDataFitness.getObjectifs();
            // Créez un HashSet des URLs de blogs existants pour une recherche plus rapide
            var existingObjectifName = new HashSet<string>(Objectif.Select(o => o.Nom));
            foreach (var objectif in SampleObjectifs)
            {
                if (!existingObjectifName.Contains(objectif.Nom))
                {
                    // Ajoutez le blog au contexte s'il n'existe pas déjà
                    Objectif.Add(objectif);
                }
            }
            // Enregistrez les changements une seule fois après avoir ajouté tous les blogs
            SaveChanges();
        }
    }


}
