using Petanque.Models;

namespace Tests
{
    public class TestTournoi
    {
        [Fact]
        public void TestCreationTournoi()
        {
            int nbJoueurs = 36;
            int nbTeteAffiche = 3;

            Tournoi? tournoi = null;
            bool notFound = true;
            int failureCounter = 0;


            while (notFound)
            {
                try
                {
                    tournoi = new Tournoi(3, nbJoueurs, 3, nbTeteAffiche);
                    notFound = false;
                }
                catch
                {
                    Console.WriteLine("Failed " + failureCounter);
                    failureCounter++;
                }
            }
            Console.WriteLine(tournoi.Resultat());
            Console.WriteLine(tournoi.ResultatNomEquipes());
        }
    }
}