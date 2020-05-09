using System;
using System.Collections.Generic;
using System.Text;

namespace Questy.Domain.Entities
{
    public class UserType
    {
        public UserType()
        {
            Permissions = new List<UserTypePermissions>();
        }
        public int ID { get; set; }
        public string Description { get; set; }
        public List<UserTypePermissions> Permissions { get; set; }
        public string AuditUser { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
