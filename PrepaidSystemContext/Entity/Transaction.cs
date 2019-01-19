using System;
using System.Collections.Generic;
using System.Text;
using PrepaidSystemContext.Enum;

namespace PrepaidSystemContext.Entity
{
    public class Transaction
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public decimal BalanceChange { get; set; }

        public int PassengerId { get; set; }

        public virtual Passenger Passenger { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public TransactionType TransactionType { get; set; }
    }
}
