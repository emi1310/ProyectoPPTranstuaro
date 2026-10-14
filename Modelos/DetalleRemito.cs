namespace Trastuaro_V2.Modelos
{
    public class DetalleRemito
    {
        public int IdDetalleRemito { get; set; }

        public int IdRemito { get; set; }

        public int CantidadBultos { get; set; }

        public string? Descripcion { get; set; }

        public string? ProveedorOrigen { get; set; }

        public string? NumeroRemitoOrigen { get; set; }

        public decimal ValorDeclarado { get; set; }

        public decimal ImporteFlete { get; set; }

        public override string ToString()
        {
            return $"{CantidadBultos} bulto(s) - {Descripcion} - ${ImporteFlete:N2}";
        }
    }
}