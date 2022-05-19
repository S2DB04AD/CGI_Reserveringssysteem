using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Reservation
    {
        public int id { get; set; }
        public DateTime ResDate { get; set; }
        public bool Used { get; set; }
        public int AmountPeople { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int WorkplaceId { get; set; }
        public int RoomNr { get; set; }
    }
}
