
using ACPApi.BL;
using ACPApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace ACPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        ClienteBL clienteBL;
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ClienteModel>> ObtenerClientes()
        {
            clienteBL = new ClienteBL();
            List<ClienteModel> clientes = new List<ClienteModel>();
            clientes = clienteBL.ObtenerClientes();
            return (clientes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ClienteModel> ObtenerCliente(int id)
        {
            clienteBL = new ClienteBL();
            ClienteModel cliente = new ClienteModel();
            cliente = clienteBL.ObtenerCliente(id);

            return cliente;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> RegistrarCliente([FromBody]ClienteModel cliente)
        {
            clienteBL = new ClienteBL();
            bool respuesta = false;
            respuesta = clienteBL.registrarCliente(cliente);
            return respuesta;

        }

    }
}
