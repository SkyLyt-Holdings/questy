using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Questy.API.Controllers.User.DTOs;
using Questy.Infrastructure.Constants;
using Questy.Infrastructure.ErrorHandling;
using Questy.Infrastructure.Helpers.Security;
using Questy.Infrastructure.Interfaces;
using Questy.Infrastructure.Services;

namespace Questy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : BaseController
    {
        private readonly IJwtManagement jwtManagement;

        public UsersController(IJwtManagement jwtManagement,
            IServiceProvider serviceProvider,
            IRepositoryWrapper repositories, 
            IConfiguration configuration) : base(serviceProvider, repositories, configuration)
        {
            this.jwtManagement = jwtManagement;
        }
       

        [HttpPost]
        [AllowAnonymous]
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
        [AllowAnonymous]
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

            var isAdmin = user.UserTypeID == UserTypes.Admin ? true : false;

            var token = jwtManagement.GenerateJwtToken(user, isAdmin);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token)});

        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserInfo(int userId)
        {
            if (IsAdmin)
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

            return Unauthorized("Access denied");
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            if (IsAdmin)
            {
                var users = await repositories.Users.FindAll()
                    .Include(x => x.UserType)
                    .Include(x => x.QuestLog)
                    .ToListAsync();
                if (users.Count == 0)
                {
                    return StatusCode(400, new BaseErrorResponse()
                    {
                        Error = true,
                        Message = "Cannot get any users from base!"
                    });
                }
                var outList = new List<UserResponseDTO>();
                foreach (var tmp in users)
                {
                    var user = new UserResponseDTO()
                    {
                        Username = tmp.Username,
                        Email = tmp.Email,
                        IsActive = tmp.isActive,
                        QuestLog = tmp.QuestLog,
                        UserType = tmp.UserType.Description
                    };
                    outList.Add(user);
                }
                return Ok(outList);
            }
            return Unauthorized("Access denied");
        }
    }
}
