﻿using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuiviFitness.Models
{
    public class Seance
    {
        public int IDSeance { get; set; }
        public int IDUtilisateur { get; set; }
        public DateTime DateHeure { get; set; }
        public string Description { get; set; }

        // Relation avec l'utilisateur
        public Utilisateur Utilisateur { get; set; }



    }
}
