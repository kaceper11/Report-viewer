using System;
using System.Collections.Generic;
using System.Text;

namespace PrepaidSystemContext.Entity
{
    public class Passenger
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public decimal Balance { get; set; }

        public string PersonalIdentification { get; set; }

        public ICollection<Card> Cards { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
