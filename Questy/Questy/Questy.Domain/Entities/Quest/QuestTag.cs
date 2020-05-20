using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string AuditUser { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime LastUpdated { get; set; }
    }
}
