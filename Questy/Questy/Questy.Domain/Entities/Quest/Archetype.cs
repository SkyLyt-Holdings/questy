using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Questy.Domain.Entities
{
    public class Archetype
    {
        public Archetype()
        {
            Tags = new List<ArchetypeTag>();
        }

        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Description { get; set; }

        public List<ArchetypeTag> Tags { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string AuditUser { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime LastUpdated { get; set; }
    }
}
