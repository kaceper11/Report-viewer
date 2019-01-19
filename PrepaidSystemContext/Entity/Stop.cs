using System;
using System.Collections.Generic;
using System.Text;

namespace PrepaidSystemContext.Entity
{
    public class Stop
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<StopOnRoute> StopsOnRoute { get; set; }
    }
}
