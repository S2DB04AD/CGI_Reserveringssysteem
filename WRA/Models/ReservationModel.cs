using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WRA.Models
{
    public class ReservationModel
    {
        public int id { get; set; }
        [Required]
        public DateTime ResDate { get; set; }
        public bool Used { get; set; }
        [Required]
        public int AmountPeople { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }
        public int WorkplaceId { get; set; }
        [Required]
        public int RoomNr { get; set; }
    }
}
