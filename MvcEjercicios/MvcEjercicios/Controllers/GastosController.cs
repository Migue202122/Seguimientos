using Microsoft.AspNetCore.Mvc;
using MvcEjercicios.Models;

namespace MvcEjercicios.Controllers
{
    public class GastosController : Controller
    {
        private static List<GastoViewModel> _gastos = new List<GastoViewModel>
        {
            new GastoViewModel { Id = 1, Monto = 50.00m, Descripcion = "Café y desayuno", Categoria = "Comida", Fecha = DateTime.Today },
            new GastoViewModel { Id = 2, Monto = 120.00m, Descripcion = "Cine y palomitas", Categoria = "Entretenimiento", Fecha = DateTime.Today.AddDays(-1) }
        };
        private static int _nextId = _gastos.Count > 0 ? _gastos.Max(g => g.Id) + 1 : 1;

        public static readonly List<string> Categorias = new List<string> { "Comida", "Transporte", "Entretenimiento", "Servicios", "Otros" };

        public IActionResult Index()
        {
            return View(CrearModeloResumen());
        }

        [HttpPost]
        public IActionResult Registrar(GastoViewModel nuevoGasto)
        {

            if (ModelState.IsValid)
            {
                nuevoGasto.Id = _nextId++;
                _gastos.Add(nuevoGasto);
                return RedirectToAction("Index");
            }

            var resumenModelo = CrearModeloResumen();
            resumenModelo.NuevoGasto = nuevoGasto; 
            return View("Index", resumenModelo);
        }

        private ResumenGastosViewModel CrearModeloResumen()
        {

            string mesActual = DateTime.Today.ToString("yyyy-MM");

            var gastosDelMes = _gastos
                .Where(g => g.MesAnio == mesActual)
                .OrderByDescending(g => g.Fecha)
                .ToList();

            decimal total = gastosDelMes.Sum(g => g.Monto);

            var totalesPorCategoria = gastosDelMes
                .GroupBy(g => g.Categoria)
                .ToDictionary(g => g.Key, g => g.Sum(i => i.Monto));

            return new ResumenGastosViewModel
            {
                Gastos = gastosDelMes,
                TotalMensual = total,
                TotalesPorCategoria = totalesPorCategoria,
                NuevoGasto = new GastoViewModel()
            };
        }
    }
}