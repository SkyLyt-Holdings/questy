﻿using Questy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Questy.Infrastructure.DTOs.User
{
    public class UserResponseDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public List<QuestLog> QuestLog { get; set; }
        public string UserType { get; set; }
    }
}