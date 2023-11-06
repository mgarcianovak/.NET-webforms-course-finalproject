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
            connection = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security = true");
            command = new SqlCommand();
            command.Connection = connection;
        }

        public void setCommandText(string commandText)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = commandText;
        }

        public void readData()
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

        public void nonQuery()
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

        public void setParameters(string parameter, object value)
        {
            command.Parameters.AddWithValue(parameter, value);
        }

        public void closeConnection()
        {
            if (reader != null) reader.Close();
            connection.Close();
        }
    }
}
