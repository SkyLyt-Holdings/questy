using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Questy.API.Controllers.User.DTOs;
using Questy.Data;
using Questy.Domain.Entities;
using Questy.Infrastructure.Constants;
using Questy.Infrastructure.ErrorHandling;
using Questy.Infrastructure.Helpers.Security;
using Questy.Infrastructure.Interfaces;
using Questy.Infrastructure.Repositories;
using Questy.Infrastructure.Services;

namespace Questy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IJwtManagement jwtManagement;

        public UsersController(IJwtManagement jwtManagement, 
            IRepositoryWrapper repositories, 
            IConfiguration configuration) : base(repositories, configuration)
        {
            this.jwtManagement = jwtManagement;
        }
       

        [HttpPost]
        public async Task<IActionResult> CreateUser(AddNewUserRequestDTO request)
        {
            var exists = await repositories.Users.FindByCondition(x => x.Username == request.Username).FirstOrDefaultAsync();

            if (exists == null)
            {
                var user = new Domain.Entities.User
                {
                    Username = request.Username,
                    Password = EncryptionHelper.HashPassword(request.Password),
                    Email = request.Email,
                    UserTypeID = request.IsAdmin ? UserTypes.Admin : UserTypes.User,
                    AuditUser = request.Username,
                    LastUpdated = DateTime.Now,
                    isActive = true
                };

                repositories.Users.Create(user);
                repositories.Save();

                return Created("~/api/users", user.Username);
            }

            return StatusCode(400, new BaseErrorResponse()
            {
                Error = true,
                Message = $"Username {request.Username} already exists, please try a different username."
            });

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserRequestDTO request)
        {

            var user = await repositories.Users.FindByCondition(x => x.Username == request.Username).FirstOrDefaultAsync();

            var correctPassword = EncryptionHelper.VerifyPassword(user.Password, request.Password);

            if (!correctPassword || user == null)
            {
                return StatusCode(400, new BaseErrorResponse()
                {
                    Error = true,
                    Message = $"Incorrect email and/or password, please try again or reset your password."
                });
            }

            var token = jwtManagement.GenerateJwtToken(user);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token)});

        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserInfo(int userId)
        {
            var user = await repositories.Users.FindByCondition(x => x.ID == userId)
                .Include(x => x.UserType)
                .Include(x => x.QuestLog)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return StatusCode(400, new BaseErrorResponse()
                {
                    Error = true,
                    Message = $"Cannot find user with ID {userId}."
                });
            }

            var responseDTO = new UserResponseDTO
            {
                Username = user.Username,
                Email = user.Email,
                IsActive = user.isActive,
                QuestLog = user.QuestLog,
                UserType = user.UserType.Description
            };

            return Ok(responseDTO);
        }

    }
}
