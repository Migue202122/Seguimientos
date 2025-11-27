using Microsoft.AspNetCore.Mvc;
using MvcEjercicios.Models;
using System.Text;

namespace MvcEjercicios.Controllers
{
    public class PasswordController : Controller
    {
        public IActionResult Index()
        {
            return View(new PasswordViewModel());
        }

        [HttpPost]
        public IActionResult Generar(PasswordViewModel model)
        {
            if (model.Longitud <= 0)
            {
                model.ContraseñaGenerada = "Error: La longitud debe ser mayor a 0.";
                return View("Index", model);
            }

            const string Minusculas = "abcdefghijklmnopqrstuvwxyz";
            const string Mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string Numeros = "0123456789";
            const string Simbolos = "!@#$%^&*()_+-=[]{};:,.<>/?";

            StringBuilder pool = new StringBuilder();
            if (model.IncluirMinusculas) pool.Append(Minusculas);
            if (model.IncluirMayusculas) pool.Append(Mayusculas);
            if (model.IncluirNumeros) pool.Append(Numeros);
            if (model.IncluirSimbolos) pool.Append(Simbolos);

            if (pool.Length == 0)
            {
                model.ContraseñaGenerada = "Error: Debes seleccionar al menos un tipo de carácter.";
                return View("Index", model);
            }

            Random random = new Random();
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < model.Longitud; i++)
            {

                int index = random.Next(pool.Length);
                password.Append(pool[index]);
            }

            model.ContraseñaGenerada = password.ToString();

            return View("Index", model);
        }
    }
}
