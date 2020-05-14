using System;
using System.Collections.Generic;
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
        public string Description { get; set; }
        public List<UserTypePermission> UserTypes { get; set; }
        public bool isActive { get; set; }
        public string AuditUser { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
