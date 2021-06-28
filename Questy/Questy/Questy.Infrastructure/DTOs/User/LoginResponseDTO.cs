using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questy.Infrastructure.DTOs.User
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }

        public string Username { get; set; }
    }
}
