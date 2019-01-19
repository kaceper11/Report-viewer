using System;
using System.Collections.Generic;
using System.Text;

namespace PrepaidSystemContext.Entity
{
    public class Departure
    {
        public int Id { get; set; }

        public DateTime DepartureTime { get; set; }

        public int DayProfileId { get; set; }

        public virtual  DayProfile DayProfile { get; set; }
    }
}
