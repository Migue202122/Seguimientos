using Microsoft.AspNetCore.Mvc;
using MvcEjercicios.Models;

namespace MvcEjercicios.Controllers
{
    public class TareasController : Controller
    {
        // Lista estática para simular el almacenamiento de datos
        private static List<Tarea> _tareas = new List<Tarea>
        {
            new Tarea { Id = 1, Descripcion = "Configurar el sistema", Completada = true },
            new Tarea { Id = 2, Descripcion = "Implementar aplicaciones", Completada = false }
        };
        private static int _nextId = _tareas.Count > 0 ? _tareas.Max(t => t.Id) + 1 : 1;

        public IActionResult Index()
        {
            return View(_tareas);
        }

        [HttpPost]
        public IActionResult Agregar(string descripcion)
        {
            if (!string.IsNullOrWhiteSpace(descripcion))
            {
                var nuevaTarea = new Tarea
                {
                    Id = _nextId++,
                    Descripcion = descripcion,
                    Completada = false
                };
                _tareas.Add(nuevaTarea);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            var tarea = _tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                _tareas.Remove(tarea);
            }
            return RedirectToAction("Index");
        }

        public IActionResult MarcarCompletada(int id)
        {
            var tarea = _tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                tarea.Completada = !tarea.Completada; 
            }
            return RedirectToAction("Index");
        }
    }
}