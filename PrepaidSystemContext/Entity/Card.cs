using System;
using System.Collections.Generic;
using System.Text;

namespace PrepaidSystemContext.Entity
{
    public class Card
    {
        public int Id { get; set; }

        public string SerialNumber { get; set; }

        public bool IsActive { get; set; }

        public int PassengerId { get; set; }

        public Passenger Passenger { get; set; }
    }
}
