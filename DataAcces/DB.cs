using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAcces
{
    public class DB
    {
        public List<Workplace> GetWorkplace()
        {
            string constr = "Server=192.168.44.250;Database=CGI_WRA;User Id=cgi-user;Password=password;Integrated Security=False;";
            List<Workplace> workplaces = new List<Workplace>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT * FROM Workplace";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Workplace workplaceList = new Workplace();
                        workplaceList.RoomNr = Convert.ToInt32(dr["RoomNr"]);
                        workplaceList.Available = Convert.ToBoolean(dr["Available"]);
                        workplaceList.Screen = Convert.ToBoolean(dr["Screen"]);
                        workplaceList.MeetingRoomId = Convert.ToInt32(dr["MeetingRoomId"]);
                        workplaces.Add(workplaceList);
                    }
                }
                return workplaces;
            }
        }
    }
}