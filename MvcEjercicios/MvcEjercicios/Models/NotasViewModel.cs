namespace MvcEjercicios.Models
{
    public class NotasViewModel
    {
        public List<Nota> NotasFiltradas { get; set; } = new List<Nota>();
        public string FiltroBusqueda { get; set; } = string.Empty;
        public string FiltroCategoria { get; set; } = string.Empty;
        public Nota NotaFormulario { get; set; } = new Nota();
    }
}