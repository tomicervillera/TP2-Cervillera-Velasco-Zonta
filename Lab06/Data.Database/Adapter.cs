using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //Miembros
        private SqlConnection _sqlConn;
        public SqlConnection SqlConn { get => _sqlConn; set => _sqlConn = value; }
        //Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringExpress";

        //M�todos
        protected void OpenConnection()
        {
            string temp;
            temp=ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            SqlConn = new SqlConnection(temp);
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


    }


}
