using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Questy.Infrastructure.DTOs.Archetype;
using Questy.Infrastructure.DTOs.QuestTag;
using Questy.Infrastructure.DTOs.Tag;
using Questy.Infrastructure.ErrorHandling;
using Questy.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ArchetypesController : BaseController
    {
        public ArchetypesController(IServiceProvider serviceProvider,
            IRepositoryWrapper repositories,
            IConfiguration configuration,
            IMapper mapper) : base(serviceProvider, repositories, configuration, mapper)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddArchetype(ArchetypeDTO request)
        {
            var exists = await repositories.Archetypes.FindByCondition(x => x.Description == request.Description).FirstOrDefaultAsync();

            if (exists == null)
            {
                var artype = new Domain.Entities.Archetype
                {
                    Description = request.Description,
                    AuditUser = UserID.ToString(),
                    LastUpdated = DateTime.Now
                };

                repositories.Archetypes.Create(artype);
                repositories.Save();

                return Created("~/api/archetypes", artype);
            }

            return StatusCode(400, new BaseErrorResponse()
            {
                Error = true,
                Message = $"Artype with description: '{request.Description}' already exists ."
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArchetype(int id)
        {
            var artype = await repositories.Archetypes.FindByCondition(x => x.ID == id).FirstOrDefaultAsync();

            if (artype == null)
            {
                return StatusCode(404, new BaseErrorResponse()
                {
                    Error = true,
                    Message = $"Cannot find artype with ID {id} ."
                });
            }

            var responseDTO = mapper.Map<ArchetypeDTO>(artype);

            return Ok(responseDTO);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateArchetype(ArchetypeDTO request)
        {
            if (IsAdmin)
            {
                var artype = await repositories.Archetypes.FindByCondition(x => x.ID == request.ID).FirstOrDefaultAsync();

                if (artype != null)
                {
                    var updatedArtype = mapper.Map(request, artype);

                    repositories.Archetypes.Update(updatedArtype);
                    repositories.Save();

                    return NoContent();
                }
                return StatusCode(400, new BaseErrorResponse()
                {
                    Error = true,
                    Message = $"Cannot get artype with ID {request.ID} ."
                });
            }

            return Unauthorized("Access denied");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArchetype(int id)
        {
            if (IsAdmin)
            {
                var artype = await repositories.Archetypes.FindByCondition(x => x.ID == id).FirstOrDefaultAsync();

                if (artype == null)
                {
                    return StatusCode(404, new BaseErrorResponse()
                    {
                        Error = true,
                        Message = $"Cannot find artype with ID {id} ."
                    });
                }

                repositories.Archetypes.Delete(artype);
                repositories.Save();

                return NoContent();
            }

            return Unauthorized("Access denied");
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllArchetypes()
        {
            var artypes = await repositories.Archetypes.FindAll().ToListAsync();
            if (artypes.Count == 0)
            {
                return StatusCode(400, new BaseErrorResponse()
                {
                    Error = true,
                    Message = "There are no artype records ."
                });
            }

            var responseDTO = mapper.Map<List<ArchetypeDTO>>(artypes);
            return Ok(responseDTO);
        }
    }
}
