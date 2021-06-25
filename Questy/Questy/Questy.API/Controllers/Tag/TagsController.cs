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
                var quest = new Domain.Entities.Tag
                {
                    Description = request.Description,
                    AuditUser = userID.ToString(),
                    LastUpdated = DateTime.Now
                };

                repositories.Tags.Create(quest);
                repositories.Save();

                return Created("~/api/tags", quest);
            }
            return StatusCode(400, new BaseErrorResponse()
            {
                Error = true,
                Message = $"Cannot create tag with description {request.Description}."
            });
        }

        [HttpGet("{tagId}")]
        public async Task<IActionResult> GetTag(int tagId)
        {
            var quest = await repositories.Tags.FindByCondition(x => x.ID == tagId).FirstOrDefaultAsync();

            if (quest == null)
            {
                return StatusCode(404, new BaseErrorResponse()
                {
                    Error = true,
                    Message = $"Cannot find tag with ID {tagId}."
                });
            }

            var responseDTO = mapper.Map<TagDTO>(quest);

            return Ok(responseDTO);
        }

        [HttpPost("UpdateTag")]
        public async Task<IActionResult> UpdateTag(TagDTO request)
        {
            if (IsAdmin)
            {
                var quest = await repositories.Tags.FindByCondition(x => x.ID == request.ID).FirstOrDefaultAsync();

                if (quest != null)
                {
                    var updatedTag = mapper.Map(request, quest);

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
                var quest = await repositories.Tags.FindByCondition(x => x.ID == tagId).FirstOrDefaultAsync();

                if (quest == null)
                {
                    return StatusCode(404, new BaseErrorResponse()
                    {
                        Error = true,
                        Message = $"Cannot find tag with ID {tagId}."
                    });
                }

                repositories.Tags.Delete(quest);
                repositories.Save();

                return NoContent();
            }
            return Unauthorized("Access denied");
        }

        [HttpGet("GetAllTags")]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await repositories.Tags.FindAll().ToListAsync();
            if (tags.Count == 0)
            {
                return StatusCode(400, new BaseErrorResponse()
                {
                    Error = true,
                    Message = "Cannot get any tags from base!"
                });
            }

            var responseDTO = mapper.Map<List<TagDTO>>(tags);
            return Ok(responseDTO);
        }

        [HttpPost("AddQuestTag")]
        public async Task<IActionResult> AddQuestTag(QuestTagDTO request)
        {
            var exists = await repositories.QuestTags
                               .FindByCondition(x => (x.QuestID == request.QuestID) && (x.TagID == request.TagID))
                               .FirstOrDefaultAsync();

            if (exists == null)
            {
                var quest = new Domain.Entities.QuestTag
                {
                    QuestID = request.QuestID,
                    TagID = request.TagID,
                    AuditUser = userID.ToString(),
                    LastUpdated = DateTime.Now
                };

                repositories.QuestTags.Create(quest);
                repositories.Save();

                return Created("~/api/tags", quest);
            }
            return StatusCode(400, new BaseErrorResponse()
            {
                Error = true,
                Message = $"Cannot create QuestTag record with quest ID {request.QuestID} and tag ID {request.TagID}."
            });
        }

        [HttpDelete("DeleteQuestTag/{qtID}")]
        public async Task<IActionResult> DeleteQuestTag(int qtID)
        {
            if (IsAdmin)
            {
                var quest = await repositories.QuestTags.FindByCondition(x => x.ID == qtID).FirstOrDefaultAsync();

                if (quest == null)
                {
                    return StatusCode(404, new BaseErrorResponse()
                    {
                        Error = true,
                        Message = $"Cannot find QuestTag record with ID {qtID}."
                    });
                }

                repositories.QuestTags.Delete(quest);
                repositories.Save();

                return NoContent();
            }
            return Unauthorized("Access denied");
        }
    }
}
