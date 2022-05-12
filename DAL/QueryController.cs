/*
 * Data Access Layer
 * Query Controller
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public static void CreateReservation(Reservation reservation)
        {
            string DateRes = reservation.ResDate.ToString("yyyy-MM-dd");
            // Add parameters to query with addWithValue function
            //  (AmountPeople, WorkplaceId, ResDate, Used, StartTime, EndTime) VALUES ({reservation.AmountPeople}, {reservation.WorkplaceId}, {reservation.ResDate}, {reservation.Used}, {reservation.StartTime}, {reservation.EndTime})
            // Original: string queryInsert = $"INSERT INTO Reservation";
            string queryInsert = @"INSERT INTO Reservation(Used, EndTime, StartTime, WorkplaceId, ResDate, AmountPeople) VALUES(1, '" + reservation.EndTime + "', '" + reservation.StartTime + "', " + reservation.WorkplaceId + ", '" + DateRes + "', " + reservation.AmountPeople + ")";
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(Reservation));
            DataTable dt = new DataTable();

            //foreach (PropertyDescriptor p in props)
            //{
            //    dt.Columns.Add(p.Name, p.PropertyType);
            //}

            // dt.Columns.Add("id");
            dt.Columns.Add("Used");
            dt.Columns.Add("EndTime");
            dt.Columns.Add("StartTime");
            dt.Columns.Add("WorkplaceId");
            dt.Columns.Add("ResDate");
            dt.Columns.Add("AmountPeople");

            // dt.Rows.Add(reservation.id);
            dt.Rows.Add(
                reservation.Used,
                reservation.EndTime,
                reservation.StartTime,
                reservation.WorkplaceId,
                reservation.ResDate,
                reservation.AmountPeople
            );



            DbController.Create(queryInsert, dt);
        }
    }
}
