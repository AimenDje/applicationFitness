using Microsoft.AspNetCore.Mvc;

namespace SuiviFitness.Controllers
{
    public class MessagerieController : Controller
    {
        public IActionResult Messagerie()
        {
            return View();
        }
    }
}
