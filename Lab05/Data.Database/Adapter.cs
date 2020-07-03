using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        private SqlConnection _sqlConn;

        public SqlConnection SqlConn { get => _sqlConn; set => _sqlConn = value; }


        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");

        protected void OpenConnection()
        {
            string temp;
            //temp=ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            SqlConn = new SqlConnection( @"Data Source = localhost\SqlExpress; Initial Catalog = academia; Integrated Security = true; ");
            SqlConn.Open();
        }

        protected void CloseConnection()
        {
            SqlConn.Close();
            SqlConn = null;

        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }

        //Clave por defecto a utlizar para la cadena de conexion
        // const string consKeyDefaultCnnString = "ConnStringExpress";





    }


}
