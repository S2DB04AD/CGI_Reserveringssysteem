using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WRA.Models
{
    public class WallOfShameModel
    {
        public string Username { get; set; }
        public string RoomNr { get; set; }
        public DateTime DateTime { get; set; }
        public bool Used { get; set; }
    }
}
