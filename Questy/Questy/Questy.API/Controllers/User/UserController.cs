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
        private static QuestyContext _context = new QuestyContext();

        [HttpGet]
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        [HttpPost]
        public bool Add([FromBody] User user)
        {
            var result = false;
            _context.Users.Add(user);
            if (_context.SaveChanges() > 0)
            {
                result = true;
            }
            return result;
        }

    }
}