namespace SuiviFitness.Models
{
    public class ProgressionService
    {
        private Utilisateur _utilisateur;

        public ProgressionService()
        {
            // Initialisez ou obtenez l'instance de l'utilisateur selon vos besoins
            _utilisateur = new Utilisateur();
        }

        public int GetProgression()
        {
            return _utilisateur.progression;
        }

        public void IncrementerProgression(int increment)
        {
            _utilisateur.progression += increment;
            // Ici, vous pouvez également gérer la persistance si nécessaire, même si ce n'est pas dans une base de données
        }
    }
}
