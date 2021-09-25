using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataBase
{
    public class Connection
    {
        public static SqlConnection GetConnection()
        {
            string connect = @"Data Source= ALLOSPC;Initial Catalog=BankApp;Integrated Security=True";
            SqlConnection myConnection = new SqlConnection(connect);
            return myConnection;
        }
    }
}
