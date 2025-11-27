using System.ComponentModel.DataAnnotations;

namespace MvcEjercicios.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        public string NombreCliente { get; set; } = string.Empty;

        [Required(ErrorMessage = "El servicio es obligatorio.")]
        public string Servicio { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha y hora son obligatorias.")]
        [DataType(DataType.DateTime)]
        public DateTime FechaHora { get; set; }

        public string FechaHoraDisplay => FechaHora.ToString("dd/MM/yyyy HH:mm");
    }
}
