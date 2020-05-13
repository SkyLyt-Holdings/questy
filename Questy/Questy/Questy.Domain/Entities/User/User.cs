using System;
using System.Collections.Generic;
using System.Text;

namespace Questy.Domain.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int UserTypeID { get; set; }
        public UserType UserType { get; set; }
        public bool isActive { get; set; }
        public string AuditUser { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
