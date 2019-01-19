using System;
using System.Collections.Generic;
using System.Text;
using PrepaidSystemContext.Enum;

namespace PrepaidSystemContext.Entity
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public byte[] PasswordSHA256 { get; set; }

        public UserRoleType Role { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
