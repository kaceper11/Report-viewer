using System;
using System.Collections.Generic;
using System.Text;

namespace PrepaidSystemContext.Entity
{
    public class Route
    {
        public int Id { get; set; }

        public int LineId { get; set; }

        public virtual Line Line { get; set; }

        public ICollection<DayOnRoute> DaysOnRoute { get; set; }

        public ICollection<StopOnRoute> StopsOnRoute { get; set; }
    }
}
