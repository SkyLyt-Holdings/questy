using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Questy.Domain.Entities
{
    public class Weight
    {
        public int ID { get; set; }

        [Required]
        public int PrimaryPercentage { get; set; }

        [Required]
        public int SecondaryPercentage { get; set; }

        [Required]
        public int TertiaryPercentage { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string AuditUser { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime LastUpdated { get; set; }
    }
}
