using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Questy.Domain.Entities
{
    public class Archetype : Entity
    {
        public Archetype()
        {
            Tags = new List<ArchetypeTag>();
        }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Description { get; set; }

        public List<ArchetypeTag> Tags { get; set; }
    }
}
