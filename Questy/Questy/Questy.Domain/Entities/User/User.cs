using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Questy.Domain.Entities
{
    public class User : Entity
    {
        public User()
        {
            QuestLog = new List<QuestLog>();
        }

        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string Email { get; set; }
        
        [Required]
        public int UserTypeID { get; set; }
        
        public UserType UserType { get; set; }
        public List<QuestLog> QuestLog { get; set; }
        public bool isActive { get; set; }
       // public string PasswordSalt { get; set; }
    }
}
