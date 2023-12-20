namespace SuiviFitness.Models
{
    public class TestDataFitness
    {
        private  static List<Exercice> listeExercices= new();

        
        public static List<Exercice> Exercices => listeExercices;

        public static Objectif?[] getObjectifs()
        {
            DateTime dateEdition = new DateTime();
            Objectif o1 = new Objectif { Nom = "Perte du poids" };
            Objectif o2 = new Objectif { Nom = "Gain du muscle" };
            Objectif o3 = new Objectif { Nom = "Renforcement musuculaire" };
            o1.Exercices = new List<Exercice>();    
            Exercice exercice1Maintien = new Exercice
            {
                NomExercice = "Exercise Maintien 1",
                Description = "Description of Exercise Maintien 1",
                Photo = "img/logo.jpg",
                Objectif = o1
            };

            o1.Exercices.Add(exercice1Maintien);
            


            Exercice exercice2Maintien = new Exercice
            {
                NomExercice = "Exercise Maintien 2",
                Description = "Description of Exercise Maintien 2",
                Photo = "img/exercise_maintien2.jpg",
                Objectif = o1
            };
            o1.Exercices.Add(exercice2Maintien);

            Exercice exercice3Maintien = new Exercice
            {
                NomExercice = "Exercise Maintien 3",
                Description = "Description of Exercise Maintien 3",
                Photo = "img/imgExercice/exercise_maintien3.jpg",
                Objectif = o1
            };
            o1.Exercices.Add(exercice3Maintien);


            return new Objectif?[] { o1, o2, o3 };

        }
    }
       
}
