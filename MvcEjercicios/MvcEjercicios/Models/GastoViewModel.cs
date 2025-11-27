using System.ComponentModel.DataAnnotations;

namespace MvcEjercicios.Models
{
    public class GastoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, 999999.99, ErrorMessage = "El monto debe ser positivo.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; } = DateTime.Now;

        public string MesAnio => Fecha.ToString("yyyy-MM");
    }
}
