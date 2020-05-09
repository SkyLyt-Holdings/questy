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
        public bool Add([FromBody] User user)
        {
            var result = false;
            context.Users.Add(user);
            if (context.SaveChanges() > 0)
            {
                result = true;
            }
            return result;
        }

    }
}