using System;
using System.Collections.Generic;
using System.Text;

namespace PrepaidSystemContext.Entity
{
    public class Log
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Text { get; set; }
    }
}
