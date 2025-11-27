using Microsoft.AspNetCore.Mvc;
using MvcEjercicios.Models;

namespace MvcEjercicios.Controllers
{
    public class PropinaController : Controller
    {
        public IActionResult Index()
        {
            return View(new PropinaViewModel());
        }

        [HttpPost]
        public IActionResult Calcular(PropinaViewModel model)
        {
            if (model.MontoTotal > 0 && model.PorcentajePropina >= 0)
            {

                model.MontoPropina = model.MontoTotal * (model.PorcentajePropina / 100.0m);

                model.TotalConPropina = model.MontoTotal + model.MontoPropina;

                return View("Index", model);
            }

            return View("Index", model);
        }
    }
}
