﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WRA.Models
{
    public class ReservationModel
    {
        public DateTime ResDate { get; set; }
        public bool Used { get; set; }
        public int AmountPeople { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}