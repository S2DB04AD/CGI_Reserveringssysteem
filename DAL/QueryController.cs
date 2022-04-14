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
    }
}