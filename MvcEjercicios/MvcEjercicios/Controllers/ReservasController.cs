using Microsoft.AspNetCore.Mvc;
using MvcEjercicios.Models;

namespace MvcEjercicios.Controllers
{
    public class ReservasController : Controller
    {
        private static List<Reserva> _reservas = new List<Reserva>
        {
            new Reserva { Id = 1, NombreCliente = "Ana López", Servicio = "Corte de pelo", FechaHora = DateTime.Now.AddDays(1).Date.AddHours(10) },
            new Reserva { Id = 2, NombreCliente = "Juan Pérez", Servicio = "Masaje relajante", FechaHora = DateTime.Now.AddDays(2).Date.AddHours(15) }
        };
        private static int _nextId = _reservas.Count > 0 ? _reservas.Max(r => r.Id) + 1 : 1;

        public static readonly List<string> ServiciosDisponibles = new List<string> { "Corte de pelo", "Masaje relajante", "Manicura y pedicura", "Consulta médica" };

        public IActionResult Index()
        {
            var model = new ReservasViewModel
            {
                ReservasExistentes = _reservas.OrderBy(r => r.FechaHora).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Confirmar(Reserva nuevaReserva)
        {
            var model = new ReservasViewModel
            {
                ReservasExistentes = _reservas.OrderBy(r => r.FechaHora).ToList(),
                NuevaReserva = nuevaReserva 
            };

            if (!ModelState.IsValid)
            {
                model.MensajeEstado = "Error: Por favor, complete todos los campos requeridos.";
                model.RegistroExitoso = false;
                return View("Index", model);
            }

            bool horarioOcupado = _reservas.Any(r => r.FechaHora == nuevaReserva.FechaHora);

            if (horarioOcupado)
            {
                model.MensajeEstado = $"Error: El horario {nuevaReserva.FechaHoraDisplay} ya está reservado. Por favor, elija otra hora.";
                model.RegistroExitoso = false;
            }
            else
            {
                nuevaReserva.Id = _nextId++;
                _reservas.Add(nuevaReserva);

                model.MensajeEstado = $"¡Éxito! Reserva para {nuevaReserva.Servicio} con el cliente {nuevaReserva.NombreCliente} confirmada para {nuevaReserva.FechaHoraDisplay}.";
                model.RegistroExitoso = true;
                model.NuevaReserva = new Reserva(); 
                model.ReservasExistentes = _reservas.OrderBy(r => r.FechaHora).ToList();
            }

            return View("Index", model);
        }
    }
}
