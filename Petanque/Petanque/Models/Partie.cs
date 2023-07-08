namespace Petanque.Models
{
    public class Partie
    {

        public Partie(List<Joueur> aEquipe1, List<Joueur> aEquipe2, char nomEquipe)
        {
            equipe1 = aEquipe1;
            for (int i = 0; i < equipe1.Count(); i++)
            {
                equipe1[i].AddNomEquipe(nomEquipe);
            }
            nomEquipe++;
            equipe2 = aEquipe2;
            for (int i = 0; i < equipe2.Count(); i++)
            {
                equipe2[i].AddNomEquipe(nomEquipe);
            }
        }

        public List<Joueur> getEquipe1()
        {
            return equipe1;
        }
        public List<Joueur> getEquipe2()
        {
            return equipe2;
        }

        private List<Joueur> equipe1;
        private List<Joueur> equipe2;

        public string Resultat(char nomEquipe)
        {
            string resultat = "";

            resultat += nomEquipe + "\t";
            for (int i = 0; i < equipe1.Count(); i++)
            {
                resultat += equipe1[i].getNumero() + "\t";
            }
            resultat += "\n";

            nomEquipe++;
            resultat += nomEquipe + "\t";
            for (int i = 0; i < equipe2.Count(); i++)
            {
                resultat += equipe2[i].getNumero() + "\t";
            }
            resultat += "\n";

            return resultat;
        }
    }
}
