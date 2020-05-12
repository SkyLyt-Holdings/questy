using System;
using System.Collections.Generic;
using System.Text;

namespace Questy.Domain.Entities
{
    public class ArchetypeTag
    {
        public int ID { get; set; }
        public int ArchetypeID { get; set; }
        public int TagID { get; set; }
        public Archetype Archetype { get; set; }
        public Tag Tag { get; set; }
    }
}
