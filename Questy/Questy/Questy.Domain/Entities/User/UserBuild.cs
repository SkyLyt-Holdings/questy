using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Questy.Domain.Entities
{
    public class UserBuild
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int ArchetypeID { get; set; }

        [Required]
        public int WeightPercentage { get; set; }

        public Archetype Archetype { get; set; }      
        
        public Weight Weight { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string AuditUser { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime LastUpdated { get; set; }
    }
}
