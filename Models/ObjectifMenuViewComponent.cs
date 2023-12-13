using Microsoft.AspNetCore.Mvc;

namespace SuiviFitness.Models
{
    public class ObjectifMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() {
            var objectifs = TestDataFitness.getObjectifs();
            return View("ObjectifMenu",objectifs);
        }
    }
}
