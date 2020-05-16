using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Questy.Domain.Entities
{
    public class Permission
    {
        public Permission()
        {
            UserTypes = new List<UserTypePermission>();
        }
        
        public int ID { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Description { get; set; }
        
        public List<UserTypePermission> UserTypes { get; set; }
        
        public bool isActive { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string AuditUser { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime LastUpdated { get; set; }
    }
}
