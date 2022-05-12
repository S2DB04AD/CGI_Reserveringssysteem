using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WRA.Models
{
    public class WallOfShameModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RoomNr { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool Used { get; set; }
    }
}
