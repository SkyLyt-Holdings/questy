using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Questy.Domain.Entities
{
    public class UserType : Entity
    {
        public UserType()
        {
            Permissions = new List<UserTypePermission>();
        }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Description { get; set; }
        
        public List<UserTypePermission> Permissions { get; set; }
    }
}
