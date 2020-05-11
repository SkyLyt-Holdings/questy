using System;
using System.Collections.Generic;
using System.Text;

namespace Questy.Domain.Entities
{
    public class UserBuild
    {
        public int ID { get; set; }
        public Archetype PrimaryArchetype { get; set; }
        public Archetype SecondaryArchetype { get; set; }
        public Archetype TertiaryArchetype { get; set; }
        public Weight Weight { get; set; }
        public string AuditUser { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
