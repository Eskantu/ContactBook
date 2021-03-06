using Examen.Core.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Examen.Core.DAL
{
    public class Connection : IConnection
    {
       private readonly SqlConnection sqlConnection;

        public Connection(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
            if (Connect() == false)
                throw new Exception("Error al conectar con servidor");
        }
        public bool Connect()
        {
            try
            {
                sqlConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Errro al conectar a Server: {ex.Message}");
            }
        }

        public bool Disconnect()
        {
            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                    sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Errro al desconectar a Server: {ex.Message}");
            }
        }

        public int ExecuteNoQuery(string query)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.CommandTimeout=60;
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al ejecutar consulta: {ex.Message}");
            }
        }

        public object ExecuteQuery(string query)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataReader result = command.ExecuteReader();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al ejecutar consulta: {ex.Message}");
            }
            
        }
    }
}
