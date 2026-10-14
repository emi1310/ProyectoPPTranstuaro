using Trastuaro_V2.Modelos;
using Trastuaro_V2.Repositories;

namespace Trastuaro_V2.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public int Agregar(Cliente cliente)
        {
            Validar(cliente);

            cliente.NombreRazonSocial =
                cliente.NombreRazonSocial.Trim();

            cliente.CuitDni =
                cliente.CuitDni.Trim();

            cliente.CondicionIva =
                cliente.CondicionIva.Trim();

            cliente.Domicilio =
                string.IsNullOrWhiteSpace(cliente.Domicilio)
                    ? null
                    : cliente.Domicilio.Trim();

            return _clienteRepository.Agregar(cliente);
        }

        public List<Cliente> ListarActivos()
        {
            return _clienteRepository.ListarActivos();
        }

        private static void Validar(Cliente cliente)
        {
            ArgumentNullException.ThrowIfNull(cliente);

            if (string.IsNullOrWhiteSpace(cliente.NombreRazonSocial))
            {
                throw new ArgumentException(
                    "Debe ingresar el nombre o razón social.");
            }

            if (string.IsNullOrWhiteSpace(cliente.CuitDni))
            {
                throw new ArgumentException(
                    "Debe ingresar el CUIT o DNI.");
            }

            if (string.IsNullOrWhiteSpace(cliente.CondicionIva))
            {
                throw new ArgumentException(
                    "Debe indicar la condición frente al IVA.");
            }
        }
    }
}