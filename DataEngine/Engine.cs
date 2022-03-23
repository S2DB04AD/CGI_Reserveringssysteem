/*
 * General Purpose Data Engine
 * Written by Thijs Haker for SGI
 */

namespace DataEngine
{
    using System.Data;
    using System.Data.SqlClient;

    public class Engine
    {
        public SqlConnection con { private set; get; }

        public Engine(string conStr)
        {
            con = new SqlConnection(conStr);
        }

        public void Start()
        {
            con.Open();
        }

        public void Stop()
        {
            con.Close();
        }

        public object[] Read(string query)
        { 
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();

            object[] vals = new Object[sdr.FieldCount];
            sdr.GetValues(vals);

            // Cleanup
            sdr.Close();
            cmd.Dispose();

            return vals;
        }

        public void Insert(string query, DataSet data)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter();
            
            sda.Fill(data);
            sda.InsertCommand = cmd;
            sda.InsertCommand.ExecuteNonQuery();

            // Cleanup
            cmd.Dispose();
        }

        public void Update(string query, DataSet data)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter();

            sda.Fill(data);
            sda.UpdateCommand = cmd;
            sda.UpdateCommand.ExecuteNonQuery();

            // Cleanup
            cmd.Dispose();

        }

        public void Delete(string query, DataSet data)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter();

            sda.Fill(data);
            sda.DeleteCommand = cmd;
            sda.DeleteCommand.ExecuteNonQuery();

            // Cleanup
            cmd.Dispose();
        }
    }

}
