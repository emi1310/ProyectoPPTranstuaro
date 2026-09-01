using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRemitosTransporte.Modelos
{
    public class DetalleRemito
    {
        public int IdDetalleRemito { get; private set; }
        public int CantidadBultos { get; private set; }
        public string Descripcion { get; private set; }
        public string ProveedorOrigen { get; private set; }
        public string NumeroRemitoOrigen { get; private set; }
        public decimal ValorDeclarado { get; private set; }
        public decimal ImporteFlete { get; private set; }

        public DetalleRemito(
            int idDetalleRemito,
            int cantidadBultos,
            string descripcion,
            string proveedorOrigen,
            string numeroRemitoOrigen,
            decimal valorDeclarado,
            decimal importeFlete)
        {
            if (cantidadBultos <= 0)
                throw new ArgumentException("La cantidad de bultos debe ser mayor que cero.");

            if (valorDeclarado < 0)
                throw new ArgumentException("El valor declarado no puede ser negativo.");

            if (importeFlete < 0)
                throw new ArgumentException("El importe del flete no puede ser negativo.");

            IdDetalleRemito = idDetalleRemito;
            CantidadBultos = cantidadBultos;
            Descripcion = descripcion;
            ProveedorOrigen = proveedorOrigen;
            NumeroRemitoOrigen = numeroRemitoOrigen;
            ValorDeclarado = valorDeclarado;
            ImporteFlete = importeFlete;
        }

        public void ActualizarValorDeclarado(decimal valor)
        {
            if (valor < 0)
                throw new ArgumentException("El valor declarado no puede ser negativo.");

            ValorDeclarado = valor;
        }

        public void ActualizarImporteFlete(decimal importe)
        {
            if (importe < 0)
                throw new ArgumentException("El importe del flete no puede ser negativo.");

            ImporteFlete = importe;
        }

        public decimal ObtenerImporteFlete()
        {
            return ImporteFlete;
        }
    }
}