using System;
using System.Collections.Generic;
using System.Text;

namespace PrepaidSystemContext.Entity
{
    public class CardUse
    {
        public int Id { get; set; }

        public int StopId { get; set; }

        public virtual Stop Stop { get; set; }

        public int CardId { get; set; }

        public virtual Card Card { get; set; }

        public int BusCourseId { get; set; }

        public virtual BusCourse BusCourse { get; set; }

        public int TransactionId { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
