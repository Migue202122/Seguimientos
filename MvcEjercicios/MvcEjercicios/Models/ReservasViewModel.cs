namespace MvcEjercicios.Models
{
    public class ReservasViewModel
    {
        public List<Reserva> ReservasExistentes { get; set; } = new List<Reserva>();
        public Reserva NuevaReserva { get; set; } = new Reserva();
        public string MensajeEstado { get; set; } = string.Empty;
        public bool RegistroExitoso { get; set; } = false;
    }
}