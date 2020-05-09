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
    public class UserTypeController : ControllerBase
    {
        private static QuestyContext context = new QuestyContext();

        [HttpGet]
        public List<UserType> GetAll()
        {
            return context.UserTypes.ToList();
        }

        [HttpPost]
        public UserType Add([FromBody] UserType userType)
        {
            context.UserTypes.Add(userType);
            context.SaveChanges();
            return userType;
        }
    }
}