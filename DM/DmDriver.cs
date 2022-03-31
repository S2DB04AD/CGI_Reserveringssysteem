/*
 * DataManager: DmDriver
 * Implements the CRUDS interface for Microsoft SQL Server
 */

namespace DataManager
{
    using System.Data;
    using System.Data.SqlClient;

    // Microsoft SQL Driver
    public class MsSqlDriver : DmCruds
    {
        public string ConStr { get; set; }
        SqlConnection Con;

        MsSqlDriver(string conStr)
        {
            ConStr = conStr;
            Con = new SqlConnection(conStr);
        }

        public void Start()
        {
            Con.Open();
        }

        public void Stop()
        {
            if (Con != null)
            {
                Con.Close();
            }
        }

        public void Create(string query, DataTable data)
        {
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataAdapter sda = new SqlDataAdapter();

            sda.Fill(data);
            sda.InsertCommand = cmd;
            sda.InsertCommand.ExecuteNonQuery();

            // Cleanup
            cmd.Dispose();
        }

        public DataTable Read(string query)
        {
            DataTable data = new DataTable();
            SqlCommand cmd = new SqlCommand(query, Con);
            data.Load(cmd.ExecuteReader());

            // Cleanup
            cmd.Dispose();
            return data;
        }

        public void Update(string query, DataTable data)
        {
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataAdapter sda = new SqlDataAdapter();

            sda.Fill(data);
            sda.UpdateCommand = cmd;
            sda.UpdateCommand.ExecuteNonQuery();

            // Cleanup
            cmd.Dispose();
        }

        public void Delete(string query)
        {
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataAdapter sda = new SqlDataAdapter();

            sda.DeleteCommand = cmd;
            sda.DeleteCommand.ExecuteNonQuery();

            // Cleanup
            cmd.Dispose();
        }

        public void Select(string query)
        {
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataAdapter sda = new SqlDataAdapter();

            sda.SelectCommand = cmd;
            sda.DeleteCommand.ExecuteNonQuery();

            // Cleanup
            cmd.Dispose();
        }
    }
}