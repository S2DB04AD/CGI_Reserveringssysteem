using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAcces
{
    public class DB
    {
        /*        string connectionString;
                SqlConnection con;

                public DataTable ConnectDB()
                {
                    connectionString = "Server=192.168.44.250;Database=CGI_WRA;User Id=cgi-user;Password=password;Integrated Security=False;";
                    con = new SqlConnection(connectionString);
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Workplace", con))
                    {
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter(cmd.ToString(), con);
                        da.Fill(dt);
                        return dt;
                    }
                }*/
        public List<Workplace> GetWorkplace()
        {
            string constr = "Server=192.168.44.250;Database=CGI_WRA;User Id=cgi-user;Password=password;Integrated Security=False;";
            List<Workplace> fruits = new List<Workplace>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT * FROM Workplace";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Workplace fruitList = new Workplace();
                        fruitList.RoomNr = Convert.ToInt32(dr["RoomNr"]);
                        fruitList.Available = Convert.ToBoolean(dr["Available"]);
                        fruitList.Screen = Convert.ToBoolean(dr["Screen"]);
                        fruitList.MeetingRoomId = Convert.ToInt32(dr["MeetingRoomId"]);
                        fruits.Add(fruitList);
                    }
                }
                return fruits;
            }
        }

        public List<Reservation> GetReservations()
        {
            string constr = "Server=192.168.44.250;Database=CGI_WRA;User Id=cgi-user;Password=password;Integrated Security=False;";
            List<Reservation> reservations = new List<Reservation>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT * FROM Reservation";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Reservation reservation = new Reservation();
                        reservation.ResDate = Convert.ToDateTime(dr["ResDate"]);
                        reservation.AmountPeople = Convert.ToInt32(dr["AmountPeople"]);
                        //reservation.StartTime = Convert.ToDateTime(dr["StartTime"]);
                        reservation.StartTime = (TimeSpan)dr["StartTime"];
                        reservation.EndTime = (TimeSpan)dr["EndTime"];
                        reservation.Used = Convert.ToBoolean(dr["Used"]);
                        reservations.Add(reservation);
                    }
                }
                return reservations;
            }
        }
    }
}