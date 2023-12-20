using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuiviFitness.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base( options ) {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Objectif>()
           .HasMany(o => o.Exercices)
           .WithOne(e => e.Objectif)
           .HasForeignKey(e => e.ObjectifId);


            base.OnModelCreating(modelBuilder);
        }
        

        public DbSet<Exercice> Exercices { get; set; }  

        public DbSet<Objectif> Objectifs { get; set; }


    }
}
