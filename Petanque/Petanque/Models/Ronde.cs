namespace Petanque.Models
{
    public class Ronde
    {
        private Partie[] parties;
        private Random rand;
        private List<Joueur> mesJoueurs;

        public Ronde(List<Joueur> joueurs, int aNbJoueursParEquipe, Random rand)
        {
            this.rand = rand;

            int[] nbJoueursParEquipe = CalculerLeNombreDeJoueurs(joueurs.Count(), aNbJoueursParEquipe); ;

            parties = new Partie[nbJoueursParEquipe.Count() / 2];

            mesJoueurs = new List<Joueur>(joueurs);

            int indexEquipe = 0;

            char nomEquipe = 'A';

            for (int i = 0; i < parties.Count(); i++)
            {
                List<Joueur> equipe1 = new List<Joueur>();
                List<Joueur> equipe2 = new List<Joueur>();

                FaireUnePartie(equipe1, equipe2, nbJoueursParEquipe[indexEquipe++], nbJoueursParEquipe[indexEquipe++]);

                parties[i] = new Partie(equipe1, equipe2, nomEquipe);
                nomEquipe++;
                nomEquipe++;
            }
        }

        private int[] CalculerLeNombreDeJoueurs(int nbJoueurs, int aNbJoueursParEquipe)
        {
            int nbEquipes = (nbJoueurs / (aNbJoueursParEquipe * 2)) * 2;
            int moduloNbEquipes = nbJoueurs % (aNbJoueursParEquipe * 2);
            if (moduloNbEquipes == 1)
            {
                throw new Exception("Il y a un joueur qui est seule");
            }
            if (moduloNbEquipes > 0)
            {
                nbEquipes += 2;
            }

            int[] nbJoueursParEquipe = new int[nbEquipes];

            int indexEquipe = 0;

            while (nbJoueurs > 0)
            {
                if (nbJoueurs > (aNbJoueursParEquipe * 2))
                {
                    nbJoueursParEquipe[indexEquipe++] = aNbJoueursParEquipe;
                    nbJoueursParEquipe[indexEquipe++] = aNbJoueursParEquipe;
                    nbJoueurs -= (aNbJoueursParEquipe * 2);
                }
                else
                {
                    int nombreParEquipe = nbJoueurs / 2;
                    nbJoueursParEquipe[indexEquipe++] = nombreParEquipe;
                    nbJoueursParEquipe[indexEquipe] = nombreParEquipe;
                    if (nbJoueurs % 2 == 1)
                    {
                        nbJoueursParEquipe[indexEquipe - 1]++;
                    }
                    if (nombreParEquipe == 1)
                    {
                        if (nbJoueurs % 2 == 0)
                        {
                            nbJoueursParEquipe[indexEquipe - 1]++;
                            nbJoueursParEquipe[indexEquipe - 3]--;
                        }
                        nbJoueursParEquipe[indexEquipe]++;
                        nbJoueursParEquipe[indexEquipe - 2]--;
                    }
                    nbJoueurs = 0;
                }


            }

            return nbJoueursParEquipe;
        }

        private void RemoveAdversaires(List<Joueur> equipe1, Joueur joueurAdverse)
        {
            for (int i = 0; i < equipe1.Count(); i++)
            {
                joueurAdverse.RemoveAdversaire(equipe1[i]);
                equipe1[i].RemoveAdversaire(joueurAdverse);
            }
        }

        private void FaireEquipe(IEnumerable<Joueur> aPartenairesPotentiels, List<Joueur> equipe, int nbJoueursEquipe, List<Joueur> autreEquipe)
        {
            //List<Joueur> partenairesPotentiels = mesJoueurs;
            List<Joueur> partenairesPotentiels = new List<Joueur>(aPartenairesPotentiels);

            for (int i = 0; i < nbJoueursEquipe; i++)
            {
                // J'obtiens mon premier joueur
                Joueur monJoueur = partenairesPotentiels[rand.Next(partenairesPotentiels.Count())];
                equipe.Add(monJoueur);
                mesJoueurs.Remove(monJoueur);

                // Je retire les adversaires potentiels
                if (autreEquipe != null)
                {
                    RemoveAdversaires(autreEquipe, monJoueur);
                }

                for (int j = 0; j < equipe.Count() - 1; j++)
                {
                    Joueur joueurAMettreAJour = equipe[j];
                    Joueur joueurCourant = equipe[equipe.Count() - 1];
                    joueurAMettreAJour.RemovePartenaire(joueurCourant);
                    joueurCourant.RemovePartenaire(joueurAMettreAJour);
                }

                // J'obtiens ses partenaires potentiels
                partenairesPotentiels = new List<Joueur>(partenairesPotentiels.Intersect(monJoueur.GetPartenairesPotentiels()));
            }
        }

        private void FaireUnePartie(List<Joueur> equipe1, List<Joueur> equipe2, int nbJoueursEquipe1, int nbJoueursEquipe2)
        {
            FaireEquipe(mesJoueurs, equipe1, nbJoueursEquipe1, null);

            // Je cree la liste des adversaires potentiels communs
            IEnumerable<Joueur> adversairePotentiels = new List<Joueur>(equipe1[0].GetAdversairesPotentiels());
            adversairePotentiels = adversairePotentiels.Intersect(mesJoueurs);
            for (int i = 1; i < equipe1.Count(); i++)
            {
                adversairePotentiels = adversairePotentiels.Intersect(equipe1[i].GetAdversairesPotentiels());
            }

            FaireEquipe(adversairePotentiels, equipe2, nbJoueursEquipe2, equipe1);
        }


        public string Resultat()
        {
            string resultat = "";
            char nomEquipe = 'A';
            for (int i = 0; i < parties.Count(); i++)
            {
                resultat += parties[i].Resultat(nomEquipe);
                nomEquipe++;
                nomEquipe++;
            }
            return resultat;
        }
    }
}
