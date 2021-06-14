using Questy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Questy.API.Controllers.User.DTOs
{
    public class UserResponseDTO
    {
        // DTO and not the entire User object (Username, Email, IsActive, QuestLog, UserType (description, not id))
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public List<QuestLog> QuestLog { get; set; }
        public string Description { get; set; }  // from User.UserType class
    }
// from UserType
