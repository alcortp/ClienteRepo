using ACPApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace ACPApi.DAO
{
    public class ClienteDAO
    {
        public List<ClienteModel> ObtenerClientes()
        {
            List<ClienteModel> clientes = new List<ClienteModel>();

            try
            {
                string ConnectionString = "Data Source=acpserver.database.windows.net;Initial Catalog=ACPDB;User ID=acpuser;Password=Peru2022";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spListarClientes", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    ClienteModel clienteModel;
                    while (reader.Read())
                    {
                        clienteModel = new ClienteModel();
                        clienteModel.Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : Convert.ToInt32(reader["Id"]);
                        clienteModel.Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? "" : Convert.ToString(reader["nombre"]);
                        clienteModel.Apellido = reader.IsDBNull(reader.GetOrdinal("apellido")) ? "" : Convert.ToString(reader["apellido"]);
                        clienteModel.FechaNac = reader.IsDBNull(reader.GetOrdinal("fechaNac")) ? DateTime.MinValue : Convert.ToDateTime(reader["fechaNac"]);
                        clienteModel.Edad = reader.IsDBNull(reader.GetOrdinal("edad")) ? 0 : Convert.ToInt32(reader["edad"]);

                        clientes.Add(clienteModel);
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return clientes;
        }

        public ClienteModel ObtenerCliente(int id)
        { 
            ClienteModel cliente = new ClienteModel();
            try
            {
                string ConnectionString = "Data Source=acpserver.database.windows.net;Initial Catalog=ACPDB;User ID=acpuser;Password=Peru2022";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spObtenerClientebyId", connection) {CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add("@id",SqlDbType.Int);
                    cmd.Parameters["@id"].Value = id;

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cliente.Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : Convert.ToInt32(reader["Id"]);
                        cliente.Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? "" : Convert.ToString(reader["nombre"]);
                        cliente.Apellido = reader.IsDBNull(reader.GetOrdinal("apellido")) ? "" : Convert.ToString(reader["apellido"]);
                        cliente.FechaNac = reader.IsDBNull(reader.GetOrdinal("fechaNac")) ? DateTime.MinValue : Convert.ToDateTime(reader["fechaNac"]);
                        cliente.Edad = reader.IsDBNull(reader.GetOrdinal("edad")) ? 0 : Convert.ToInt32(reader["edad"]);

                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return cliente;
        }

        public bool registrarCliente(ClienteModel cliente)
        {
            try
            {
                string ConnectionString = "Data Source=acpserver.database.windows.net;Initial Catalog=ACPDB;User ID=acpuser;Password=Peru2022";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spCrearCliente", connection) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar);
                    cmd.Parameters.Add("@fechaNac", SqlDbType.VarChar);
                    cmd.Parameters["@nombre"].Value = cliente.Nombre;
                    cmd.Parameters["@apellido"].Value = cliente.Apellido;
                    cmd.Parameters["@fechaNac"].Value = cliente.FechaNac;


                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
