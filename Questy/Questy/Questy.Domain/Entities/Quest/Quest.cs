using System;
using System.Collections.Generic;
using System.Text;

namespace Questy.Domain.Entities
{
    public class Quest
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string AuditUser { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
