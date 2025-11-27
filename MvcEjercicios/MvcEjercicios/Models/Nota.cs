using System.ComponentModel.DataAnnotations;

namespace MvcEjercicios.Models
{
    public class Nota
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, ErrorMessage = "El título no debe exceder los 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El contenido es obligatorio.")]
        [DataType(DataType.MultilineText)] 
        public string Contenido { get; set; } = string.Empty;

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public string Categoria { get; set; } = "General";

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime FechaUltimaEdicion { get; set; } = DateTime.Now;
    }
}