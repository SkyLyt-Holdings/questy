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
using Questy.Domain.Entities;
using Questy.Domain.Entities.System;
using Questy.Infrastructure.DTOs.Quest;
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
    public class QuestsController : BaseController
    {
        public QuestsController(IServiceProvider serviceProvider,
            IRepositoryWrapper repositories,
            IConfiguration configuration,
            IMapper mapper) : base(serviceProvider, repositories, configuration, mapper)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddQuest(QuestDTO request)
        {
            if (IsAdmin)
            {
                var exists = await repositories.Quests.FindByCondition(x => x.ID == request.ID).FirstOrDefaultAsync();

                if (exists == null)
                {
                    var quest = new Domain.Entities.Quest
                    {
                        Title = request.Title,
                        Description = request.Description,
                        StartDate = request.StartDate == null ? DateTime.Now : Convert.ToDateTime(request.StartDate),
                        EndDate = Convert.ToDateTime(request.EndDate),
                        AuditUser = userID.ToString(),
                        LastUpdated = DateTime.Now
                    }; 


                    repositories.Quests.Create(quest);
                    repositories.Save();

                    return Created("~/api/quests", quest.Title);
                }
                return StatusCode(400, new BaseErrorResponse()
                {
                    Error = true,
                    Message = $"Cannot create quest with ID {request.ID}."
                });
            }
            return Unauthorized("Access denied");
        }

        [HttpGet("{questId}")]
        public async Task<IActionResult> GetQuest(int questId)
        {
            var quest = await repositories.Quests.FindByCondition(x => x.ID == questId).FirstOrDefaultAsync();

            if (quest == null)
            {
                return StatusCode(404, new BaseErrorResponse()
                {
                    Error = true,
                    Message = $"Cannot find quest with ID {questId}."
                });
            }

            var responseDTO = mapper.Map<QuestDTO>(quest);

            return Ok(responseDTO);
        }

        [HttpPost("UpdateQuest")]
        public async Task<IActionResult> UpdateQuest(QuestDTO request)
        {
            if (IsAdmin)
            {
                var quest = await repositories.Quests.FindByCondition(x => x.ID == request.ID).FirstOrDefaultAsync();

                if (quest != null)
                {
                    var updatedQuest = mapper.Map(request, quest);

                    repositories.Quests.Update(updatedQuest);
                    repositories.Save();

                    return NoContent();
                }
                return StatusCode(400, new BaseErrorResponse()
                {
                    Error = true,
                    Message = $"Cannot get quest with ID {request.ID}."
                });
            }
            return Unauthorized("Access denied");
        }
    }
}