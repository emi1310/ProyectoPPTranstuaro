using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRemitosTransporte.Modelos
{
    public class Cliente
    {
        public int IdCliente { get; private set; }
        public string NombreRazonSocial { get; private set; }
        public string Domicilio { get; private set; }
        public string CuitDni { get; private set; }
        public string CondicionIVA { get; private set; }
        public bool TieneCuentaCorriente { get; private set; }
        public bool Activo { get; private set; }

        public Cliente(
            int idCliente,
            string nombreRazonSocial,
            string domicilio,
            string cuitDni,
            string condicionIVA,
            bool tieneCuentaCorriente)
        {
            IdCliente = idCliente;
            NombreRazonSocial = nombreRazonSocial;
            Domicilio = domicilio;
            CuitDni = cuitDni;
            CondicionIVA = condicionIVA;
            TieneCuentaCorriente = tieneCuentaCorriente;
            Activo = true;
        }

        public void ActualizarDatos(string domicilio, string cuitDni, string condicionIVA)
        {
            Domicilio = domicilio;
            CuitDni = cuitDni;
            CondicionIVA = condicionIVA;
        }

        public void HabilitarCuentaCorriente()
        {
            TieneCuentaCorriente = true;
        }

        public void DeshabilitarCuentaCorriente()
        {
            TieneCuentaCorriente = false;
        }

        public void DarDeBaja()
        {
            Activo = false;
        }
    }
}