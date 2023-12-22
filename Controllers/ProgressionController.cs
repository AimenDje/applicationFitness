using Microsoft.AspNetCore.Mvc;
using SuiviFitness.Models;

namespace SuiviFitness.Controllers
{
    public class ProgressionController : Controller
    {
        public IActionResult Progression()
        {
            // Créez une instance du modèle
            Progression model = new Progression();
            return View(model);
        }

        // Action pour effectuer le calcul
        [HttpPost]
        public ActionResult Effectuer(Progression model)
        {   
            // Ajoutez 10 à la variable pourcentageProgres
            model.PourcentageProgres += 10;
            
            // Passez le modèle à la vue
            return View("Progression", model);
        }
    }
}
