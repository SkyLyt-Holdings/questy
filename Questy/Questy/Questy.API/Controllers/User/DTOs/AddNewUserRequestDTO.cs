﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Questy.API.Controllers.User.DTOs
{
    public class AddNewUserRequestDTO : UserRequestDTO
    {
        [Required]
        public string Email { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
