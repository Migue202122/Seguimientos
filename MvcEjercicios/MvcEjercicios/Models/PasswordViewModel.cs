namespace MvcEjercicios.Models
{
    public class PasswordViewModel
    {
        public int Longitud { get; set; } = 12; 
        public bool IncluirMayusculas { get; set; } = true;
        public bool IncluirMinusculas { get; set; } = true;
        public bool IncluirNumeros { get; set; } = true;
        public bool IncluirSimbolos { get; set; } = false;

        public string ContraseñaGenerada { get; set; } = string.Empty;
    }
}