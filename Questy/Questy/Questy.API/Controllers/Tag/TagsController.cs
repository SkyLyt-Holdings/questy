using AutoMapper;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Questy.Domain.Entities.System;
using Questy.Infrastructure.DTOs.Quest;
using Questy.Infrastructure.DTOs.QuestTag;
using Questy.Infrastructure.DTOs.Tag;
using Questy.Infrastructure.ErrorHandling;
using Questy.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TagsController : BaseController
    {
        public TagsController(IServiceProvider serviceProvider,
            IRepositoryWrapper repositories,
            IConfiguration configuration,
            IMapper mapper) : base(serviceProvider, repositories, configuration, mapper)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddTag(TagDTO request)
        {
            var exists = await repositories.Tags.FindByCondition(x => x.Description == request.Description).FirstOrDefaultAsync();

            if (exists == null)
            {
                var tag = new Domain.Entities.Tag
                {
                    Description = request.Description,
                    AuditUser = UserID.ToString(),
                    LastUpdated = DateTime.Now
                };

                repositories.Tags.Create(tag);
                repositories.Save();

                return Created("~/api/tags", tag);
            }

            return StatusCode(400, new BaseErrorResponse()
            {
                Error = true,
                Message = $"Tag with description: '{request.Description}' already exists."
            });
        }

        [HttpGet("{tagId}")]
        public async Task<IActionResult> GetTag(int tagId)
        {
            var tag = await repositories.Tags.FindByCondition(x => x.ID == tagId).FirstOrDefaultAsync();

            if (tag == null)
            {
                return StatusCode(404, new BaseErrorResponse()
                {
                    Error = true,
                    Message = $"Cannot find tag with ID {tagId}."
                });
            }

            var responseDTO = mapper.Map<TagDTO>(tag);

            return Ok(responseDTO);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateTag(TagDTO request)
        {
            if (IsAdmin)
            {
                var tag = await repositories.Tags.FindByCondition(x => x.ID == request.ID).FirstOrDefaultAsync();

                if (tag != null)
                {
                    var updatedTag = mapper.Map(request, tag);

                    repositories.Tags.Update(updatedTag);
                    repositories.Save();

                    return NoContent();
                }
                return StatusCode(400, new BaseErrorResponse()
                {
                    Error = true,
                    Message = $"Cannot get tag with ID {request.ID}."
                });
            }

            return Unauthorized("Access denied");
        }

        [HttpDelete("{tagId}")]
        public async Task<IActionResult> DeleteTag(int tagId)
        {
            if (IsAdmin)
            {
                var tag = await repositories.Tags.FindByCondition(x => x.ID == tagId).FirstOrDefaultAsync();

                if (tag == null)
                {
                    return StatusCode(404, new BaseErrorResponse()
                    {
                        Error = true,
                        Message = $"Cannot find tag with ID {tagId}."
                    });
                }

                repositories.Tags.Delete(tag);
                repositories.Save();

                return NoContent();
            }

            return Unauthorized("Access denied");
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await repositories.Tags.FindAll().ToListAsync();
            if (tags.Count == 0)
            {
                return StatusCode(400, new BaseErrorResponse()
                {
                    Error = true,
                    Message = "There are no tags."
                });
            }

            var responseDTO = mapper.Map<List<TagDTO>>(tags);
            return Ok(responseDTO);
        }

        [HttpPost("add-quest-tag")]
        public async Task<IActionResult> AddQuestTag(QuestTagDTO request)
        {
            var exists = await repositories.QuestTags
                               .FindByCondition(x => (x.QuestID == request.QuestID) && (x.TagID == request.TagID))
                               .FirstOrDefaultAsync();

            if (exists == null)
            {
                var tag = new Domain.Entities.QuestTag
                {
                    QuestID = request.QuestID,
                    TagID = request.TagID,
                    AuditUser = UserID.ToString(),
                    LastUpdated = DateTime.Now
                };

                repositories.QuestTags.Create(tag);
                repositories.Save();

                return Created("~/api/tags", tag);
            }

            return StatusCode(400, new BaseErrorResponse()
            {
                Error = true,
                Message = $"QuestTag record with quest ID {request.QuestID} and tag ID {request.TagID} already exists."
            });
        }

        [HttpDelete("delete-quest-tag/{questTagID}")]
        public async Task<IActionResult> DeleteQuestTag(int questTagID)
        {
            if (IsAdmin)
            {
                var tag = await repositories.QuestTags.FindByCondition(x => x.ID == questTagID).FirstOrDefaultAsync();

                if (tag == null)
                {
                    return StatusCode(404, new BaseErrorResponse()
                    {
                        Error = true,
                        Message = $"Cannot find QuestTag record with ID {questTagID}."
                    });
                }

                repositories.QuestTags.Delete(tag);
                repositories.Save();

                return NoContent();
            }

            return Unauthorized("Access denied");
        }
    }
}
