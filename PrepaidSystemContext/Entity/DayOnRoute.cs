using System;
using System.Collections.Generic;
using System.Text;

namespace PrepaidSystemContext.Entity
{
    public class DayOnRoute
    {
        public DateTime DateTime { get; set; }

        public int RouteId { get; set; }

        public virtual Route Route { get; set; }

        public int DayProfileId { get; set; }

        public virtual DayProfile DayProfile { get; set; }
    }
}
