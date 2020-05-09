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
        public bool Add([FromBody] UserType userType)
        {
            var result = false;
            context.UserTypes.Add(userType);
            if (context.SaveChanges() > 0)
            {
                result = true;
            }
            return result;
        }

        [HttpPost]
        [Route("/Delete")]
        public bool Delete([FromBody] UserType userType)
        {
            var result = false;
            context.UserTypes.Remove(userType);
            if (context.SaveChanges() > 0)
            {
                result = true;
            }
            return result;
        }
    }
}