using Microsoft.AspNetCore.Mvc;
using Petanque.Models;

namespace Petanque.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public string Get(int nbJoueurs, int nbTeteAffiche)
        {
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
            return tournoi.Resultat() + tournoi.ResultatNomEquipes();
        }
    }
}