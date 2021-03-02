using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questy.API.Controllers.User.DTOs;
using Questy.Data;
using Questy.Domain.Entities;
using Questy.Infrastructure.Constants;
using Questy.Infrastructure.ErrorHandling;
using Questy.Infrastructure.Helpers.Security;
using Questy.Infrastructure.Repositories;

namespace Questy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserRepository _userRepository;

        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
       

        [HttpPost("admin")]
        public async Task<IActionResult> CreateAdminUser(AddNewUserRequestDTO request)
        {

            try
            {
                var exists = await _userRepository.FindByCondition(x => x.Username == request.Username).FirstOrDefaultAsync();

                if (exists == null)
                {
                    var user = new Domain.Entities.User();
                    user.Username = request.Username;
                    user.Password = EncryptionHelper.HashPassword(request.Password);
                    user.Email = request.Email;
                    user.UserTypeID = UserTypes.Admin;
                    user.AuditUser = request.Username;
                    user.LastUpdated = DateTime.Now;
                    user.isActive = true;

                    _userRepository.Create(user);

                    return Ok(user.Username);
                }

                return StatusCode(400, new BaseErrorResponse()
                {
                    Error = true,
                    Message = $"Username {request.Username} already exists, please try a different username."
                });

            }
            catch (Exception ex)
            {
                //TODO: implement logging

                return StatusCode(500, new BaseErrorResponse()
                {
                    Error = true,
                    Message = $"An error occurred while processing the request.",
                    DetailedMessage = ex.Message
                });
            }
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(UserRequestDTO request)
        {

            try
            {
                var user = await _userRepository.FindByCondition(x => x.Username == request.Username).FirstOrDefaultAsync();

                if (user == null)
                {
                    return StatusCode(404, new BaseErrorResponse()
                    {
                        Error = true,
                        Message = $"No user found with the username: {request.Username}."
                    });
                }

                var correctPassword = EncryptionHelper.VerifyPassword(user.Password, request.Password);

                if (!correctPassword)
                {
                    return StatusCode(400, new BaseErrorResponse()
                    {
                        Error = true,
                        Message = $"Incorrect password, please try again or reset your password."
                    });
                }


                return Ok();

            }
            catch (Exception ex)
            {
                //TODO: implement logging

                return StatusCode(500, new BaseErrorResponse()
                {
                    Error = true,
                    Message = $"An error occurred while processing the request.",
                    DetailedMessage = ex.Message
                });
            }
        }

    }
}
