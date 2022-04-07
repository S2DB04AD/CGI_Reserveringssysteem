using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces;

namespace DAL
{
    public class DbConn
    {
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
