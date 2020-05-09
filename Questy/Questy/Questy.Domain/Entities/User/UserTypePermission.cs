using System;
using System.Collections.Generic;
using System.Text;

namespace Questy.Domain.Entities
{
    public class UserTypePermissions
    {
        public int UserTypeID { get; set; }
        public int PermissionID { get; set; }
        public UserType UserType { get; set; }
        public Permission Permission { get; set; }
    }
}
