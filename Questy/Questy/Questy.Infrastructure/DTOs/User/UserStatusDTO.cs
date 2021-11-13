using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questy.Infrastructure.DTOs.User
{
    public class UserStatusDTO
    {
        [Required]
        public int UserID { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
