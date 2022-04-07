using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    internal class Reservations
    {
        // Look at all the inputs from the form on Reservations page, what needs to be sended tot the database?
        // Date - Number of people - Room ID - Start time - End time

        // Properties
        public string queryDB;
        public DateTime date;
        public int amountPeople;
        public int roomID;
        public TimeSpan startTime;
        public TimeSpan endTime;

        
        // Methods
        public void sendData()
        {
            // Parameters for query
            date = DateTime.Now;
            amountPeople = 1;
            roomID = 1;
            startTime = TimeSpan.Zero;
            endTime = TimeSpan.Zero;

            // Query to database
            queryDB = "INSERT INTO Reservations (Date, AmountPeople, WorkplaceId, StartTime, EndTime) VALUES (?, ?, ?, ?, ?)";

            // Add parameters to query
        }
    }
}
