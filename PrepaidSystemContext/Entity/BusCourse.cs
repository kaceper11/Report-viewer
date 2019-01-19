using System;
using System.Collections.Generic;
using System.Text;

namespace PrepaidSystemContext.Entity
{
    public class BusCourse
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public virtual Route Route { get; set; }

        public DateTime? DateTime { get; set; }
    }
}
