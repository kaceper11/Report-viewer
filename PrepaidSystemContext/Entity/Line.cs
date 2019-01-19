using System;
using System.Collections.Generic;
using System.Text;

namespace PrepaidSystemContext.Entity
{
    public class Line
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Route> Routes { get; set; }
    }
}
