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

 
            //-----------  Data Exercices de Perte de Poids  ------------- 
            o1.Exercices = new List<Exercice>();    
            Exercice exercice1PertePoids = new Exercice
            {

                NomExercice = "Échauffement (5-10 minutes) : ",
                Description = "Debout, les pieds joints, sautez en étendant les bras\r\n" +
                " et les jambes pour former une étoile. Répétez pendant 1 minute. Rotation des bras et des jambes",
                Photo = "images/imgExercice/jumping-jack.gif",
                Objectif = o1
            };

            o1.Exercices.Add(exercice1PertePoids);
            
            Exercice exercice2PertePoids = new Exercice
            {
                NomExercice = "Course à pied ou Jogging : ",
                Description = "Une activité cardiovasculaire classique\r\n" +
                " qui brûle des calories et améliore la santé cardiovasculaire.",
                Photo = "images/imgExercice/jogging.gif",
                Objectif = o1
            };
            o1.Exercices.Add(exercice2PertePoids);

            Exercice exercice3PertePoids = new Exercice
            {
                NomExercice = "Entraînement cardiovasculaire à haute intensité (HIIT) : ",
                Description = "Alternez des périodes courtes d'activité de 30 sec intense (sprint, saut à la corde)\r\n" +
                " avec des périodes de repos actif ou de faible intensité.",
                Photo = "images/imgExercice/saut-corde.gif",
                Objectif = o1
            };
            o1.Exercices.Add(exercice3PertePoids);

            Exercice exercice4PertePoids = new Exercice
            {
                NomExercice = "Planche avec élévation de jambe : ",
                Description = "En position de planche , soulevez une jambe à la fois vers le plafond.\r\n" +
                " Alternez de chaque côté, en faisant 3 séries de 12 élévations.",
                Photo = "images/imgExercice/planche-lever-jambe.gif",
                Objectif = o1
            };
            o1.Exercices.Add(exercice4PertePoids);


            //------------------------------------------------------------  


            //----------  Data Exercices de Gains Musculaire  ------------ 
            o2.Exercices = new List<Exercice>();
            Exercice exercice1Gain = new Exercice
            {
                NomExercice = "Extension des Mollets à la Presse : ",
                Description = "Réalisez une flexion avec les muscles des mollets\r\n" +
                " afin de développer la charge. Poussez aussi loin que possible!\r\n" +
                " 3 Series de 12 répétitions avec 30 seconde de pause.",
                Photo = "images/imgExercice/extensions-mollets.gif",
                Objectif = o2
            };
            o2.Exercices.Add(exercice1Gain);


            Exercice exercice2Gain = new Exercice
            {
                NomExercice = "Exercise Gain 2",
                Description = "Description of Exercise Gain 2",
                Photo = "images/imgExercice/squat-low-barre.gif",
                Objectif = o2
            };
            o2.Exercices.Add(exercice2Gain);

            Exercice exercice3Gain = new Exercice
            {
                NomExercice = "Exercise Gain 3",
                Description = "Description of Exercise Gain 3",
                Photo = "images/imgExercice/russian-twist-avec-haltere.gif",
                Objectif = o2
            };
            o2.Exercices.Add(exercice3Gain);


            Exercice exercice4Gain = new Exercice
            {
                NomExercice = "Exercise Gain 4",
                Description = "Description of Exercise Gain 4",
                Photo = "images/imgExercice/biceps-curl-haltere.gif",
                Objectif = o2
            };
            o2.Exercices.Add(exercice4Gain);


            Exercice exercice5Gain = new Exercice
            {
                NomExercice = "Exercise Gain 5",
                Description = "Description of Exercise Gain 5",
                Photo = "images/imgExercice/developpe-epaule-halteres.gif",
                Objectif = o2
            };
            o2.Exercices.Add(exercice5Gain);



           Exercice exercice6Gain = new Exercice
            {
                NomExercice = "Exercise Gain 6",
                Description = "Description of Exercise Gain 6",
                Photo = "images/imgExercice/developper-coucher.gif",
                Objectif = o2
            };
            o2.Exercices.Add(exercice6Gain);

            Exercice exercice7Gain = new Exercice
            {
                NomExercice = "Exercise Gain 7",
                Description = "Description of Exercise Gain 7",
                Photo = "images/imgExercice/tirage-horizontal-prise-large.gif",
                Objectif = o2
            };
            o2.Exercices.Add(exercice7Gain);
            //------------------------------------------------------------ 

            //----------  Data Exercices de renforcement Musculaire  ------------ 
            o3.Exercices = new List<Exercice>();
            Exercice exercice1Renforcement = new Exercice
            {
                NomExercice = "Exercise renforcement de pompe :",
                Description = "Faire 3 series de 12 répétitions",
                Photo = "images/imgExercice/push-up.gif",
                Objectif = o3
            };

            o3.Exercices.Add(exercice1Renforcement);

            Exercice exercice2Renforcement = new Exercice
            {
                NomExercice = "Exercise renforcement de traction : ",
                Description = "Faire 3 series de 8 répétitions",
                Photo = "images/imgExercice/pull-up.gif",
                Objectif = o3
            };
            o3.Exercices.Add(exercice2Renforcement);

            Exercice exercice3Renforcement = new Exercice
            {
                NomExercice = "Exercise renforcement de redressement assis : ",
                Description = "Faire 3 series de 16 répétitions",
                Photo = "images/imgExercice/sit-up.gif",
                Objectif = o3
            };
            o3.Exercices.Add(exercice3Renforcement);


            Exercice exercice4Renforcement = new Exercice
            {
                NomExercice = "Exercise renforcement de squat : ",
                Description = "Faire 3 series de 14 répétitions",
                Photo = "images/imgExercice/squat.gif",
                Objectif = o3
            };
            o3.Exercices.Add(exercice4Renforcement);
            //------------------------------------------------------------ 



            return new Objectif?[] { o1, o2, o3 };

        }
    }
       
}
