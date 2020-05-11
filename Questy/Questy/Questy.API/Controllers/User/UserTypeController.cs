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
        private static QuestyContext _context = new QuestyContext();

        [HttpGet]
        public List<UserType> GetAll()
        {
            return _context.UserTypes.ToList();
        }

        [HttpPost]
        public bool Add([FromBody] UserType userType)
        {
            var result = false;
            _context.UserTypes.Add(userType);
            if (_context.SaveChanges() > 0)
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
            _context.UserTypes.Remove(userType);
            if (_context.SaveChanges() > 0)
            {
                result = true;
            }
            return result;
        }
    }
}