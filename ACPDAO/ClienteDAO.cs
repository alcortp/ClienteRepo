using ACPDominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACPDAO
{
    public class ClienteDAO
    {
        public List<ClienteDominio> ObtenerClientes()
        { 
            List<ClienteDominio> clientes = new List<ClienteDominio>();

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
                    ClienteDominio clienteDominio = new ClienteDominio();
                    while (reader.Read())
                    {
                        clienteDominio.Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : Convert.ToInt32(reader["Id"]);
                        clienteDominio.Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? "" : Convert.ToString(reader["nombre"]);
                        clienteDominio.Apellido = reader.IsDBNull(reader.GetOrdinal("apellido")) ? "" : Convert.ToString(reader["apellido"]);
                        clienteDominio.FechaNac = reader.IsDBNull(reader.GetOrdinal("fechaNac")) ? DateTime.MinValue : Convert.ToDateTime(reader["fechaNac"]);
                        clienteDominio.Edad = reader.IsDBNull(reader.GetOrdinal("edad")) ? 0 : Convert.ToInt32(reader["edad"]);

                        clientes.Add(clienteDominio);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            Console.ReadKey();

            return clientes;
        }
    }
}
