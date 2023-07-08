namespace Petanque.Models
{
    public class Joueur
    {
        public Joueur(int i)
        {
            numero = i;
            adversairesPotentiels = new List<Joueur>();
            partenairesPotentiels = new List<Joueur>();
            nomEquipe = new List<String>();
        }

        public void AddPartenaire(Joueur partenaire)
        {
            partenairesPotentiels.Add(partenaire);        }

        public void RemovePartenaire(Joueur partenaire)
        {
            if (!partenairesPotentiels.Remove(partenaire))
                throw new Exception("Double remove partenaire");
        }

        public List<Joueur> GetPartenairesPotentiels()
        {
            return partenairesPotentiels;
        }

        public void AddNomEquipe(char equipe)
        {
            nomEquipe.Add("" + equipe);
        }

        public string GetNomEquipe(int index)
        {
            return nomEquipe[index];
        }

        public void AddAdversaire(Joueur adversaire)
        {
            adversairesPotentiels.Add(adversaire);
        }

        public void RemoveAdversaire(Joueur adversaire)
        {
            if (!adversairesPotentiels.Remove(adversaire))
                throw new Exception("Double remove adversaire");
        }

        public List<Joueur> GetAdversairesPotentiels()
        {
            return adversairesPotentiels;
        }

        public int getNumero()
        {
            return numero;
        }

        public int getNbAdversairesPotentiels()
        {
            return adversairesPotentiels.Count();
        }

        public int getNbPartenairesPotentiels()
        {
            return partenairesPotentiels.Count();
        }

        private List<Joueur> partenairesPotentiels;
        private List<Joueur> adversairesPotentiels;
        private int numero;
        private List<String> nomEquipe;

        /*@Override
        public String toString()
        {
            return "" + numero;
        }*/
    }
}
