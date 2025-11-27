using Microsoft.AspNetCore.Mvc;
using MvcEjercicios.Models;

namespace MvcEjercicios.Controllers
{
    public class NotasController : Controller
    {
        private static List<Nota> _notas = new List<Nota>
        {
            new Nota { Id = 1, Titulo = "Ideas para el proyecto final", Contenido = "Implementar autenticación con Identity y migrar a Entity Framework.", Categoria = "Trabajo" },
            new Nota { Id = 2, Titulo = "Lista de compras", Contenido = "Leche, huevos, pan integral y café.", Categoria = "Personal" }
        };
        private static int _nextId = _notas.Count > 0 ? _notas.Max(n => n.Id) + 1 : 1;

        public static readonly List<string> Categorias = new List<string> { "General", "Trabajo", "Estudios", "Personal", "Finanzas" };

        public IActionResult Index(string filtroBusqueda, string filtroCategoria)
        {
            var notasFiltradas = _notas.AsEnumerable();

            if (!string.IsNullOrEmpty(filtroCategoria) && filtroCategoria != "Todas")
            {
                notasFiltradas = notasFiltradas.Where(n => n.Categoria == filtroCategoria);
            }

            if (!string.IsNullOrEmpty(filtroBusqueda))
            {
                string busquedaLower = filtroBusqueda.ToLower();
                notasFiltradas = notasFiltradas.Where(n =>
                    n.Titulo.ToLower().Contains(busquedaLower) ||
                    n.Contenido.ToLower().Contains(busquedaLower));
            }

            var model = new NotasViewModel
            {
                NotasFiltradas = notasFiltradas.OrderByDescending(n => n.FechaUltimaEdicion).ToList(),
                FiltroBusqueda = filtroBusqueda ?? string.Empty,
                FiltroCategoria = filtroCategoria ?? string.Empty
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Guardar(Nota nota)
        {
            if (ModelState.IsValid)
            {
                if (nota.Id == 0) 
                {
                    nota.Id = _nextId++;
                    nota.FechaCreacion = DateTime.Now;
                    nota.FechaUltimaEdicion = DateTime.Now;
                    _notas.Add(nota);
                }
                else 
                {
                    var notaExistente = _notas.FirstOrDefault(n => n.Id == nota.Id);
                    if (notaExistente != null)
                    {
                        notaExistente.Titulo = nota.Titulo;
                        notaExistente.Contenido = nota.Contenido;
                        notaExistente.Categoria = nota.Categoria;
                        notaExistente.FechaUltimaEdicion = DateTime.Now;
                    }
                }
                return RedirectToAction("Index");
            }

            var model = new NotasViewModel
            {
                NotasFiltradas = _notas.OrderByDescending(n => n.FechaUltimaEdicion).ToList(),
                NotaFormulario = nota
            };
            return View("Index", model);
        }

        public IActionResult Editar(int id)
        {
            var nota = _notas.FirstOrDefault(n => n.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            var model = new NotasViewModel
            {
                NotasFiltradas = _notas.OrderByDescending(n => n.FechaUltimaEdicion).ToList(),
                NotaFormulario = nota
            };
            return View("Index", model);
        }

        public IActionResult Eliminar(int id)
        {
            var nota = _notas.FirstOrDefault(n => n.Id == id);
            if (nota != null)
            {
                _notas.Remove(nota);
            }
            return RedirectToAction("Index");
        }
    }
}
