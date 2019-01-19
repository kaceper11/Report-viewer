using System;
using System.Collections.Generic;
using System.Text;

namespace PrepaidSystemContext.Entity
{
    public class StopOnRoute
    {
        public int RouteId { get; set; }

        public virtual Route Route { get; set; }

        public int StopId { get; set; }

        public virtual Stop Stop { get; set; }

        public int MinuteSinceDeparture { get; set; }
    }
}
