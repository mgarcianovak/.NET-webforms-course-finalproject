using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class DataAccess
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public SqlDataReader Reader { get { return reader; } }

        public DataAccess()
        {
            connection = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security = true");
            command = new SqlCommand
            {
                Connection = connection
            };
        }

        public void SetCommandText(string commandText)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = commandText;
        }

        public void SetStoredProcedure(string storedProcedure)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = storedProcedure;
        }
        public void SetParameter(string parameter, object value)
        {
            command.Parameters.AddWithValue(parameter, value);
        }

        public void ReadData()
        {
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteNonQuery()
        {
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CloseConnection()
        {
            reader?.Close();
            connection.Close();
        }
    }
}
