namespace Trastuaro_V2.Modelos
{
    public class Remito
    {
        public int IdRemito { get; set; }

        public string NumeroRemito { get; set; } = string.Empty;

        public DateTime Fecha { get; set; } = DateTime.Today;

        public int IdCliente { get; set; }

        public string CondicionPago { get; set; } = string.Empty;

        public string Estado { get; set; } = "Pendiente";

        public decimal TotalFlete { get; set; }

        public override string ToString()
        {
            return $"Remito {NumeroRemito} - {Fecha:dd/MM/yyyy} - ${TotalFlete:N2}";
        }
    }
}