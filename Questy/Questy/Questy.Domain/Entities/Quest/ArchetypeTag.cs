using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Questy.Domain.Entities
{
    public class ArchetypeTag : Entity
    {
        public int ArchetypeID { get; set; }

        public int TagID { get; set; }

        public Archetype Archetype { get; set; }
        
        public Tag Tag { get; set; }
    }
}
