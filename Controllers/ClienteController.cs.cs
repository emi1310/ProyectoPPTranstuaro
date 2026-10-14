using Trastuaro_V2.Modelos;
using Trastuaro_V2.Services;

namespace Trastuaro_V2.Controllers
{
    public class ClienteController
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public int RegistrarCliente(Cliente cliente)
        {
            return _clienteService.Agregar(cliente);
        }

        public List<Cliente> ListarClientesActivos()
        {
            return _clienteService.ListarActivos();
        }
    }
}