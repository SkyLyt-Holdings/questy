using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questy.API.Controllers.User.DTOs
{
    public class AddNewUserRequestDTO : UserRequestDTO
    {
        public string Email { get; set; }
    }
}
