using System;
using System.Collections.Generic;
using System.Text;

namespace Questy.Domain.Entities
{
    public class QuestTag
    {
        public int ID { get; set; }
        public int QuestID { get; set; }
        public int TagID { get; set; }
        public Quest Archetype { get; set; }
        public Tag Tag { get; set; }
        public string AuditUser { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
