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
            string query = "SELECT Reservation.id, Reservation.ResDate, Reservation.Used, Reservation.AmountPeople, Reservation.StartTime, Reservation.EndTime, Workplace.RoomNr FROM Reservation INNER JOIN Workplace ON Reservation.WorkplaceId = Workplace.id";
            // string query = "select * from Reservation";
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
                    EndTime = (TimeSpan)(values[5]),
                    RoomNr = Convert.ToInt32(values[6])
                };
                reservationList.Add(reservation);
            }
            return reservationList;

        }

        public static List<WorkplaceArea> GetReservationsListWorkplace()
        {
            string query = "SELECT ID, AmountPeople, Accessories, Name, Number, Used FROM WorkplaceArea";
            DataTable dt = DbController.Read(query);
            List<WorkplaceArea> reservationList = new List<WorkplaceArea>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
            {
                var values = row.ItemArray;
                var reservation = new WorkplaceArea()
                {
                    ID = Convert.ToInt32(values[0]),
                    AmountPeople = Convert.ToInt32(values[1]),
                    Accessories = Convert.ToString(values[2]),
                    Name = Convert.ToString(values[3]),
                    Number = Convert.ToInt32(values[4]),
                    Used = Convert.ToInt32(values[5])
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

        public static void CreateReservationWorkplace(WorkplaceArea reservation)
        {
            int Used = reservation.Used;
            string Name = reservation.Name;
            int Number = reservation.Number;
            string Accesories = reservation.Accessories;
            int AmountPeople = reservation.AmountPeople;
            string queryInsert = @"INSERT INTO WorkplaceArea (Used, Name, Number, Accessories, AmountPeople) VALUES (" + Used + ", '" + Name + "', " + Number + ", '" + Accesories + "', " + AmountPeople + ");";
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(Reservation));
            DataTable dt = new DataTable();

            // dt.Columns.Add("id");
            dt.Columns.Add("Used");
            dt.Columns.Add("Name");
            dt.Columns.Add("Number");
            dt.Columns.Add("Accesories");
            dt.Columns.Add("AmountPeople");

            // dt.Rows.Add(reservation.id);
            dt.Rows.Add(
                reservation.Used,
                reservation.Name,
                reservation.Number,
                reservation.Accessories,
                reservation.AmountPeople
            );



            DbController.Create(queryInsert, dt);
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
            string query = "select [User].id, Username, Used from [User] INNER JOIN Reservation ON [User].id = Reservation.id";
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

        public static List<WallOfShame> GetReservationsFromUserWallOfShame(int resId)
        {
            string query = "" +
                "select [User].id, Username, Workplace.RoomNr, ResDate, StartTime, EndTime, Used " +
                "from Reservation " +
                "INNER JOIN Workplace ON Reservation.id = Workplace.id " +
                "INNER JOIN [User] ON Reservation.id = [User].id " +
                "where Reservation.id = " + resId + "";
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
    }
}
