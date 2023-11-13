using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace SuiviFitness.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
       options) : base(options)
        {
        }
        // DbSet pour vos entités

        public DbSet<Utilisateur> listeUtilisateur { get; set; }
        public DbSet<Seance> seances { get; set; }
        public DbSet<Exercice> exercices { get; set; }
        public DbSet<DetailSeance> details{ get; set; }
        public DbSet<DonneeNutritionnelle> donneesNutritionnelles { get; set; }
        public DbSet<Progression> progressions { get; set; }
        public DbSet<RecommendationFitness> recommendations { get; set; }

        public void SeedData() 
        {
            // Obtenez la liste d'utilisateurs avec des données préremplies
            var sampleUtilisteurs = TestDataFitness.GetSampleUtilisateurs();

            // Créez un HashSet des nom, prénom, adresse email, mot de passe et
            // le type d'utilisteur d'utilisateurs existants pour une recherche plus rapide
            var existingUtilisteurNon = new HashSet<string>(listeUtilisateur.Select(u => u.nom));
            var existingUtilisteurPrenom = new HashSet<string>(listeUtilisateur.Select(u => u.prenom));
            var existingUtilisteurEmail = new HashSet<string>(listeUtilisateur.Select(u => u.adresseEmail));
            var existingUtilisteurMdp = new HashSet<string>(listeUtilisateur.Select(u => u.motDePasseHash));
            var existingUtilisteurType = new HashSet<string>(listeUtilisateur.Select(u => u.typeUtilisateur));

            //Parcoure chaque attribues de l'utilisateur et ajoute sa valeur s'il n'existe pas deja dans la base de donnée
            foreach (var user in sampleUtilisteurs)
            {
                if (!existingUtilisteurNon.Contains(user.nom)) { listeUtilisateur.Add(user); }
                if (!existingUtilisteurPrenom.Contains(user.prenom)) { listeUtilisateur.Add(user); }
                if (!existingUtilisteurEmail.Contains(user.adresseEmail)) { listeUtilisateur.Add(user); }
                if (!existingUtilisteurMdp.Contains(user.motDePasseHash)) { listeUtilisateur.Add(user); }
                if (!existingUtilisteurType.Contains(user.typeUtilisateur)) { listeUtilisateur.Add(user); }
            }
            // Enregistrez les changements une seule fois après avoir ajouté tous les blogs
            SaveChanges();

        }

    }
}
