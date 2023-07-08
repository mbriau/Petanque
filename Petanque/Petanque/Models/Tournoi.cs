namespace Petanque.Models
{
    public class Tournoi
    {
        public Tournoi(int nbRondes, int nbJoueurs, int nbJoueursParEquipe, int nbTeteAffiches)
        {
            rand = new Random(DateTime.Now.Millisecond);

            int nbEquipes = nbJoueurs / nbJoueursParEquipe;
            if (nbTeteAffiches > nbEquipes)
            {
                throw new Exception("Il y a plus de tetes d'affiches " + nbTeteAffiches + " que d'equipes " + nbEquipes);
            }

            rondes = new Ronde[nbRondes];
            joueurs = new List<Joueur>();

            for (int i = 0; i < nbJoueurs; i++)
            {
                joueurs.Add(new Joueur(i + 1));
            }

            for (int i = 0; i < nbJoueurs; i++)
            {
                for (int j = 0; j < nbJoueurs; j++)
                {
                    if (i != j)
                    {
                        joueurs[i].AddAdversaire(joueurs[j]);
                        if (i < nbTeteAffiches && j < nbTeteAffiches)
                        {
                            // Les tetes d'affiche ne jouent pas avec les autres
                        }
                        else
                        {
                            joueurs[i].AddPartenaire(joueurs[j]);
                        }
                    }
                }
            }

            for (int i = 0; i < rondes.Count(); i++)
            {
                rondes[i] = new Ronde(joueurs, nbJoueursParEquipe, rand);
            }
        }

        private Random rand;

        public string Resultat()
        {
            string resultat = "";
            for (int i = 0; i < rondes.Count(); i++)
            {
                resultat += "Resultat de la ronde : " + (i + 1) + "\n";
                resultat += rondes[i].Resultat();
                resultat += "\n";
            }

            /*for(int i = 0; i < joueurs.size(); i++)
            {
                int nbAdversairesVoulus = joueurs.size() - (rondes.length * nbJoueursParEquipe) - 1;

                int nbPartenairesVoulus = joueurs.size() - (rondes.length * (nbJoueursParEquipe - 1)) - 1;
                if(i < nbTeteAffiches)
                    nbPartenairesVoulus -= (nbTeteAffiches - 1);

                if(joueurs.get(i).getNbAdversairesPotentiels() != nbAdversairesVoulus)
                {
                    resultat += "ERREUR adversaires, on veut " + nbAdversairesVoulus + " mais on a " + joueurs.get(i).getNbAdversairesPotentiels() + "\n";
                }
                if(joueurs.get(i).getNbPartenairesPotentiels() != nbPartenairesVoulus)
                {
                    resultat += "ERREUR partenaires\n";
                }
            }*/
            return resultat;
        }

        public string ResultatNomEquipes()
        {
            string resultat = "";
            for (int i = 0; i < rondes.Count(); i++)
            {
                resultat += "Nom des equipes de la ronde : " + (i + 1) + "\n";

                for (int j = 0; j < joueurs.Count(); j++)
                {
                    resultat += joueurs[j].GetNomEquipe(i) + "\n";
                }
                resultat += "\n";
            }
            return resultat;
        }



        public Ronde[] getRondes()
        {
            return rondes;
        }

        Ronde[] rondes;
        List<Joueur> joueurs;

        /*public static void main(String[] args)
        {
            if (args.Count() != 2)
            {
                Console.WriteLine("Specifier le nombre de joueurs et tetes d'affiche");
                return;
            }

            int nbJoueurs = Integer.parseInt(args[0]);
            int nbTeteAffiche = Integer.parseInt(args[1]);

            Tournoi tournoi = null;
            bool notFound = true;


            while (notFound)
            {
                tournoi = new Tournoi(3, nbJoueurs, 3, nbTeteAffiche);
                notFound = false;
            }
            Console.WriteLine(tournoi.Resultat());
            Console.WriteLine(tournoi.ResultatNomEquipes());
        }*/
    }
}
