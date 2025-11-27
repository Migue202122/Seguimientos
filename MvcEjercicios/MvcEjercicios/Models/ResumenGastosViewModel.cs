namespace MvcEjercicios.Models
{
    public class ResumenGastosViewModel
    {
        public List<GastoViewModel> Gastos { get; set; } = new List<GastoViewModel>();
        public decimal TotalMensual { get; set; }
        public Dictionary<string, decimal> TotalesPorCategoria { get; set; } = new Dictionary<string, decimal>();
        public GastoViewModel NuevoGasto { get; set; } = new GastoViewModel();
    }
}