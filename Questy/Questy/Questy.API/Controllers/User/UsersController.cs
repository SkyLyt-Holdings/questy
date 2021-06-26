using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Questy.Infrastructure.Constants;
using Questy.Infrastructure.ErrorHandling;
using Questy.Infrastructure.Helpers.Security;
using Questy.Infrastructure.Interfaces;
using Questy.Infrastructure.Services;
using AutoMapper;
using Questy.Infrastructure.DTOs.User;

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
            IConfiguration configuration,
            IMapper mapper) : base(serviceProvider, repositories, configuration, mapper)
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
                    IsActive = true
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

            if (user != null)
            {
                var correctPassword = EncryptionHelper.VerifyPassword(user.Password, request.Password);

                if (correctPassword)
                {
                    var isAdmin = user.UserTypeID == UserTypes.Admin ? true : false;

                    var token = jwtManagement.GenerateJwtToken(user, isAdmin);

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
            }

            return StatusCode(400, new BaseErrorResponse()
            {
                Error = true,
                Message = $"Incorrect email and/or password, please try again or reset your password."
            });
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

                var responseDTO = mapper.Map<UserResponseDTO>(user);

                return Ok(responseDTO);
            }

            return Unauthorized("Access denied");
        }
        [HttpGet]
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

                var responseDTO = mapper.Map<List<UserResponseDTO>>(users);
                return Ok(responseDTO);
            }
            return Unauthorized("Access denied");
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(NewUserPasswordRequestDTO request)
        {
            var user = await repositories.Users.FindByCondition(x => x.ID == request.UserID).FirstOrDefaultAsync();

            if (user != null)
            {
                var correctPassword = EncryptionHelper.VerifyPassword(user.Password, request.OldPassword);
                if (!correctPassword)
                {
                    return StatusCode(400, new BaseErrorResponse()
                    {
                        Error = true,
                        Message = $"Incorrect old password, please try again."
                    });
                }
                else
                {
                    user.Password = EncryptionHelper.HashPassword(request.NewPassword);

                    repositories.Users.Update(user);
                    repositories.Save();

                    return NoContent();
                }
            }

            return StatusCode(400, new BaseErrorResponse()
            {
                Error = true,
                Message = $"User with ID {request.UserID} does not exists, please try a different UserID."
            });
        }

        [HttpPost("ChangeUserStatus")]
        public async Task<IActionResult> ChangeUserStatus(UserStatusDTO request)
        {

            var user = await repositories.Users.FindByCondition(x => x.ID == request.UserID).FirstOrDefaultAsync();

            if (user != null)
            {
                if (IsAdmin || (user.ID == userID))
                {
                    user.IsActive = request.IsActive;

                    repositories.Users.Update(user);
                    repositories.Save();

                    return NoContent();
                }
                return StatusCode(401, new BaseErrorResponse()
                {
                    Error = true,
                    Message = "You do not have access to change this users status"
                });
            }
            return StatusCode(400, new BaseErrorResponse()
            {
                Error = true,
                Message = $"User with ID {request.UserID} does not exists, please try a different UserID."
            });
        }
    }
}
