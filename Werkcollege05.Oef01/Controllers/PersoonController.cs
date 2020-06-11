using Microsoft.AspNetCore.Mvc;
using Werkcollege05.Oef01.Models;

namespace Werkcollege05.Oef01.Controllers
{
    public class PersoonController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Naam,Wachtwoord,WachtwoordControle,Email,Leeftijd,FavorietSpel")] Persoon persoon)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
            }

            return View(persoon);            
        }
    }
}
