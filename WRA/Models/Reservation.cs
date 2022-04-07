using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRA.Models
{
    public class Reservation
    {
        public DateTime dateSearch;
        public int amountPeople;
        public int workspaceID;
        public DateTime startTime;
        public DateTime endTime;

        // Constructor(s)
        public Reservation(DateTime datesearch, int amountpeople, int workspaceid, DateTime starttime, DateTime endtime)
        {
            dateSearch = datesearch;
            amountPeople = amountpeople;
            workspaceID = workspaceid;  
            startTime = starttime;
            endTime = endtime;
        }
    }
}
