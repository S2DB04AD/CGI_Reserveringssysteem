using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataAcces
{
    public class Class1
    {
        string connectionString = "";
        SqlConnection con;

        public Class1(SqlConnection con)
        {
            this.con = con;
        }

        public void ConnectDB()
        {
            connectionString = "Data Source=192.168.44.250;Initial Catalog=CGI_WRA;User ID=ubermensch;Password=Padv1nders;";
            con = new SqlConnection(connectionString);
            con.Open();
        }
    }
}