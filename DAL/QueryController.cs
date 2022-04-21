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

        public static List<WallOfShame> GetWallOfShameList()
        {
            string query = "select Username, RoomNr, ResDate, StartTime, EndTime from Reservation INNER JOIN Workplace ON Reservation.id = Workplace.id INNER JOIN [User] ON Reservation.id = [User].id";
            DataTable dt = DbController.Read(query);
            List<WallOfShame> wallOfShameList = new List<WallOfShame>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
            {
                var values = row.ItemArray;
                var wallOfShame = new WallOfShame()
                {
                    UserName = Convert.ToString(values[0]),
                    RoomNr = Convert.ToInt32(values[1]),
                    Date = Convert.ToDateTime(values[2]),
                    StartTime = (TimeSpan)(values[3]),
                    EndTime = (TimeSpan)(values[4])
                };
                wallOfShameList.Add(wallOfShame);
            }
            return wallOfShameList;
        }
    }
}