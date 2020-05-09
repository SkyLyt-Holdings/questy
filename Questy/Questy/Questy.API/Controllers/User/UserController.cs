using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questy.Data;
using Questy.Domain.Entities;

namespace Questy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static QuestyContext context = new QuestyContext();

        [HttpGet]
        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        [HttpPost]
        public User Add([FromBody] User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

    }
}