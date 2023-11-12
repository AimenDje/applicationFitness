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

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Exercice> Exercices { get; set; }
        public DbSet<DetailSeance> Details{ get; set; }
        public DbSet<DonneeNutritionnelle> DonneesNutritionnelles { get; set; }
        public DbSet<Progression> Progressions { get; set; }
        public DbSet<RecommendationFitness> Recommendations { get; set; }
       

    }
}
