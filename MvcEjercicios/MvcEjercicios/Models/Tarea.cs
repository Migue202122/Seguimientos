namespace MvcEjercicios.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Completada { get; set; }
    }
}
