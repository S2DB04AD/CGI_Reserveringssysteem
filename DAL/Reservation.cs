using System;

namespace DAL
{
    public class Reservation
    {
        public int id { get; set; }
        public string UserId { get; set; }
        public DateTime ResDate { get; set; }
        public bool Used { get; set; }
        public int AmountPeople { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int WorkplaceId { get; set; }
        public int RoomNr { get; set; }
    }
}
