using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questy.Data;
using Questy.Domain.Entities;

namespace Questy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBuildsController : ControllerBase
    {
        private readonly QuestyContext _context;

        public UserBuildsController(QuestyContext context)
        {
            _context = context;
        }

        // GET: api/UserBuilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBuild>>> GetUserBuilds()
        {
            return await _context.UserBuilds.ToListAsync();
        }

        // GET: api/UserBuilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserBuild>> GetUserBuild(int id)
        {
            var userBuild = await _context.UserBuilds.FindAsync(id);

            if (userBuild == null)
            {
                return NotFound();
            }

            return userBuild;
        }

        // PUT: api/UserBuilds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserBuild(int id, UserBuild userBuild)
        {
            if (id != userBuild.ID)
            {
                return BadRequest();
            }

            _context.Entry(userBuild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBuildExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserBuilds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserBuild>> PostUserBuild(UserBuild userBuild)
        {
            _context.UserBuilds.Add(userBuild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserBuild", new { id = userBuild.ID }, userBuild);
        }

        // DELETE: api/UserBuilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserBuild>> DeleteUserBuild(int id)
        {
            var userBuild = await _context.UserBuilds.FindAsync(id);
            if (userBuild == null)
            {
                return NotFound();
            }

            _context.UserBuilds.Remove(userBuild);
            await _context.SaveChangesAsync();

            return userBuild;
        }

        private bool UserBuildExists(int id)
        {
            return _context.UserBuilds.Any(e => e.ID == id);
        }
    }
}
