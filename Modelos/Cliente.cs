namespace Trastuaro_V2.Modelos
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string NombreRazonSocial { get; set; } = string.Empty;

        public string? Domicilio { get; set; }

        public string CuitDni { get; set; } = string.Empty;

        public string CondicionIva { get; set; } = string.Empty;

        public bool TieneCuentaCorriente { get; set; }

        public bool Activo { get; set; } = true;

        public override string ToString()
        {
            return $"{NombreRazonSocial} - {CuitDni}";
        }
    }
}