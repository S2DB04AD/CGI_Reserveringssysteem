using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAcces
{
    public class Class1
    {
        string connectionString = "";
        SqlConnection con;
        string query = "";

        public void ConnectDB()
        {
            connectionString = @"Data Source=192.168.44.250;Initial Catalog=CGI_WRA;User ID=ubermensch;Password=Padv1nders.;";
            // connectionString = @"Data Source=192.168.44.250\KITESERVER;Initial Catalog=CGI_WRA;Persist Security Info=true;User ID=ubermensch;Password=Padv1nders.;";
            con = new SqlConnection(connectionString);
            con.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Workplace", con))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}