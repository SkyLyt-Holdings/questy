using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Questy.Domain.Entities
{
    public class User
    {
        public int ID { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string Email { get; set; }
        
        [Required]
        public int UserTypeID { get; set; }
        
        public UserType UserType { get; set; }
        
        public bool isActive { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string AuditUser { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime LastUpdated { get; set; }
    }
}
