using System;
using System.Collections.Generic;
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
        public string Description { get; set; }
        public List<ArchetypeTag> Tags { get; set; }
        public string AuditUser { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
