namespace SuiviFitness.Models
{
    public class TestDataFitness
    {
        public static List<Utilisateur> GetSampleUtilisateurs()
        {
            var utilisteurs = new List<Utilisateur>();
            {
                new Utilisateur
                {
                    nom = "Djemaoune",
                    prenom = "Aimen",
                    adresseEmail = "AimenDjemaoune@gmail.com",
                    motDePasseHash = "Qwerty!123",
                    typeUtilisateur = "Sportif",
                    certifications = "Non",
                    SeancesEntrainements = new List<Seance>
                    {
                        new Seance
                        {
                            Description = "Pompes",
                            DateHeure = new DateTime(2023,09,01)
                        },
                        new Seance
                        {
                            Description = "Redréssement assis",
                            DateHeure = new DateTime(2023,09,02)
                        },
                        new Seance
                        {
                            Description = "Traction",
                            DateHeure = new DateTime(2023,09,03)
                        }
                    }
                };
                new Utilisateur
                {
                    nom = "Milongo",
                    prenom = "Serge",
                    adresseEmail = "SergeMilongo@gmail.com",
                    motDePasseHash = "Asdfgh!123",
                    typeUtilisateur = "Sportif",
                    certifications = "Non",
                    SeancesEntrainements = new List<Seance>
                    {
                        new Seance
                        {
                            Description = "Pompes",
                            DateHeure = new DateTime(2023,09,01)
                        },
                        new Seance
                        {
                            Description = "Redréssement assis",
                            DateHeure = new DateTime(2023,09,02)
                        },
                        new Seance
                        {
                            Description = "Traction",
                            DateHeure = new DateTime(2023,09,03)
                        }
                    }
                };
                new Utilisateur
                {
                    nom = "Raoui",
                    prenom = "Taha",
                    adresseEmail = "TahaRaoui@gmail.com",
                    motDePasseHash = "Zxcvbn!123",
                    typeUtilisateur = "Coatch",
                    certifications = "Oui",
                    SeancesEntrainements = new List<Seance>
                    {
                        new Seance
                        {
                            Description = "Assite aux pompes",
                            DateHeure = new DateTime(2023,09,01)
                        },
                        new Seance
                        {
                            Description = "Assite aux redressement assis",
                            DateHeure = new DateTime(2023,09,02)
                        },
                        new Seance
                        {
                            Description = "tAssite aux ractions",
                            DateHeure = new DateTime(2023,09,03)
                        }
                    }
                };
                return utilisteurs;
            }
        }
    }
}
