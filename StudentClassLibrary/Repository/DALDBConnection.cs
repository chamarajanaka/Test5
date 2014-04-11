using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassLibrary.Repository
{
    class DALDBConnection
    {
        public DALDBConnection()
        {

        }
        private static string m_connectionString;
        private static SqlConnection m_sqlConnection;


        public static SqlConnection SqlConnectionRes
        {
            get
            {
                try
                {
                    m_sqlConnection = null;
                    if (m_sqlConnection == null)
                    {
                        m_connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();

                        m_sqlConnection = new SqlConnection(m_connectionString);
                    }
                    if (m_sqlConnection.State == System.Data.ConnectionState.Closed || m_sqlConnection.State == System.Data.ConnectionState.Broken)
                    {
                        m_sqlConnection.Open();
                    }


                }
                catch (SqlException e)
                {
                    //MessageBox.Show(e.Message, "Message");
                }
                return m_sqlConnection;
            }
        }

    }
}
