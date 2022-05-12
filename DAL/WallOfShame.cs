using System;

namespace DAL
{
    public class WallOfShame
    {
        public string UserName { get; set; }
        public int RoomNr { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
