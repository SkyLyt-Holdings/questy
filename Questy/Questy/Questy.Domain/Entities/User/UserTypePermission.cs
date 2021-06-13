using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Questy.Domain.Entities
{
    public class UserTypePermission : Entity
    {
        public int UserTypeID { get; set; }
        
        public int PermissionID { get; set; }

        public UserType UserType { get; set; }
        
        public Permission Permission { get; set; }
    }
}
