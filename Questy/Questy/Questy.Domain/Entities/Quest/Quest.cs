using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Questy.Domain.Entities
{
    public class Quest : Entity
    {
        public Quest()
        {
            Tags = new List<QuestTag>();
        }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }
        
        [Column(TypeName = "datetime2")]
        public DateTime? StartDate { get; set; }
        
        [Column(TypeName = "datetime2")]
        public DateTime? EndDate { get; set; }
        
        public List<QuestTag> Tags { get; set; }
    }
}
