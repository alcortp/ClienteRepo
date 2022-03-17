using ACPApi.DAO;
using ACPApi.Models;

namespace ACPApi.BL
{
    public class ClienteBL
    {
        ClienteDAO clienteDAO;
        public List<ClienteModel> ObtenerClientes()
        {
            clienteDAO = new ClienteDAO();
            List<ClienteModel> Clientes = new List<ClienteModel>();
            Clientes = clienteDAO.ObtenerClientes();
            return Clientes;

        }

        public ClienteModel ObtenerCliente(int id)
        {
            clienteDAO = new ClienteDAO();
            ClienteModel cliente = new ClienteModel();
            cliente = clienteDAO.ObtenerCliente(id);
            return cliente;
        }

        public bool registrarCliente(ClienteModel cliente)
        {
            clienteDAO = new ClienteDAO();
            bool respuesta = false;
            respuesta = clienteDAO.registrarCliente(cliente);
            return respuesta;
        }
    }
}
