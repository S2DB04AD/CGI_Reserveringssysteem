/*
 * Data Access Layer
 * Database Controller
 */

namespace DAL
{
    using System.Data;
    using System.Data.SqlClient;

    public static class DbController
    {
        static SqlConnection Con;

        public static void Start(string conStr)
        {
            Con = new SqlConnection(conStr);
            Con.Open();
        }

        public static void Stop()
        {
            if (Con != null)
            {
                Con.Close();
            }
        }

        public static void Create(string query, DataTable data)
        {
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            // sda.Fill(data);
            sda.InsertCommand = cmd;
            sda.InsertCommand.ExecuteNonQuery();

            // Cleanup
            cmd.Dispose();
        }

        // Execute raw query, return datatable
        public static DataTable Read(string query)
        {
            DataTable data = new DataTable();
            SqlCommand cmd = new SqlCommand(query, Con);
            data.Load(cmd.ExecuteReader());

            // Cleanup
            cmd.Dispose();
            return data;
        }

        public static void Update(string query, DataTable data)
        {
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataAdapter sda = new SqlDataAdapter();
            // updatecommand
            sda.SelectCommand = cmd;
            sda.Fill(data);
           
            sda.UpdateCommand.ExecuteNonQuery();

            // Cleanup
            cmd.Dispose();
        }

        public static void Delete(string query)
        {
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataAdapter sda = new SqlDataAdapter();

            sda.DeleteCommand = cmd;
            sda.DeleteCommand.ExecuteNonQuery();

            // Cleanup
            cmd.Dispose();
        }
    }
}
