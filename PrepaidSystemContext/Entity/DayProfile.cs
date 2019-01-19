using System;
using System.Collections.Generic;
using System.Text;

namespace PrepaidSystemContext.Entity
{
    public class DayProfile
    {
        public int Id { get; set; }

        public ICollection<Departure> Departures { get; set; }
    }
}
