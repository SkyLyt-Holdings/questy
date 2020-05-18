using System;
using System.ComponentModel.DataAnnotations;

namespace Questy.Domain.Entities
{
    public class QuestLog
    {
        public int ID { get; set; }
        public int UserID { get; set; } // FK to Users table
        public int QuestID { get; set; } // FK to Quests table
        public User User { get; set; }
        public Quest Quest { get; set; }
        [Required]
        public bool IsCompleted { get; set; } = false;
        public string AuditUser { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}