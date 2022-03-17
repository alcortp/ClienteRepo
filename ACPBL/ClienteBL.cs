using ACPDAO;
using ACPDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACPBL
{
    public class ClienteBL
    {
        ClienteDAO clienteDao;
        public List<ClienteDominio> ObtenerClientes()
        {
            clienteDao = new ClienteDAO();
            List<ClienteDominio> Clientes = new List<ClienteDominio>();
            Clientes = clienteDao.ObtenerClientes();
            return Clientes;
                                
        }
    }
}
