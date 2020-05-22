using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questy.Domain.Entities
{
    public interface IEntity
    {
        int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        string AuditUser { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        DateTime LastUpdated { get; set; }
    }
}
