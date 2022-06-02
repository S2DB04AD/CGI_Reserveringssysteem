/*
 * Data Access Layer
 * Query Controller
 */

using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public static class QueryController
    {
        public static List<Reservation> GetReservationsList()
        {
            string query = "select * from Reservation";
            DataTable dt = DbController.Read(query);
            List<Reservation> reservationList = new List<Reservation>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
            {
                var values = row.ItemArray;
                var reservation = new Reservation()
                {
                    id = Convert.ToInt32(values[0]),
                    ResDate = Convert.ToDateTime(values[1]),
                    Used = Convert.ToBoolean(values[2]),
                    AmountPeople = Convert.ToInt32(values[3]),
                    StartTime = (TimeSpan)(values[4]),
                    EndTime = (TimeSpan)(values[5])
                };
                reservationList.Add(reservation);
            }
            return reservationList;

        }

        public static List<WallOfShame> GetWallOfShameList(int id)
        {
            string query = "" +
                "select [User].id, Username, Workplace.RoomNr, ResDate, StartTime, EndTime, Used " +
                "from Reservation " +
                "INNER JOIN Workplace ON Reservation.id = Workplace.id " +
                "INNER JOIN [User] ON Reservation.id = [User].id " +
                "where [User].id = " + id + "";
            DataTable dt = DbController.Read(query);
            List<WallOfShame> wallOfShameList = new List<WallOfShame>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
            {
                var values = row.ItemArray;
                var wallOfShame = new WallOfShame()
                {
                    UserId = Convert.ToInt32(values[0]),
                    UserName = Convert.ToString(values[1]),
                    RoomNr = Convert.ToInt32(values[2]),
                    Date = Convert.ToDateTime(values[3]),
                    StartTime = (TimeSpan)(values[4]),
                    EndTime = (TimeSpan)(values[5]),
                    Used = Convert.ToBoolean(values[6])
                };
                wallOfShameList.Add(wallOfShame);
            }
            return wallOfShameList;
        }

        public static List<WallOfShame> GetUserNamesWallOfShame()
        {
            string query = "" +
                "select [User].id, Username, Used " +
                "from [User] " +
                "INNER JOIN Reservation ON [User].id = Reservation.id";
            DataTable dt = DbController.Read(query);
            List<WallOfShame> wallOfShameList = new List<WallOfShame>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
            {
                var values = row.ItemArray;
                var wallOfShame = new WallOfShame()
                {
                    UserId = Convert.ToInt32(values[0]),
                    UserName = Convert.ToString(values[1]),
                    Used = Convert.ToBoolean(values[2])
                };
                wallOfShameList.Add(wallOfShame);
            }
            return wallOfShameList;
        }
    }
}