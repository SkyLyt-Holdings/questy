using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Questy.Infrastructure.DTOs.Quest;
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
            var exists = await repositories.Quests.FindByCondition(x => x.Title == request.Title).FirstOrDefaultAsync();

            if (exists == null)
            {
                var quest = new Domain.Entities.Quest
                {
                    Title = request.Title,
                    Description = request.Description,
                    StartDate = request.StartDate == null ? DateTime.Now : Convert.ToDateTime(request.StartDate),
                    EndDate = request.EndDate == null ? null : Convert.ToDateTime(request.EndDate),
                    AuditUser = UserID.ToString(),
                    LastUpdated = DateTime.Now
                };

                repositories.Quests.Create(quest);
                repositories.Save();

                return Created("~/api/quests", new { messsage = "success" });
            }

            return StatusCode(400, new BaseErrorResponse()
            {
                Error = true,
                Message = $"Quest with title '{request.Title}' already exists."
            });
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

        [HttpGet]
        public async Task<IActionResult> GetAllQuests()
        {
            var quests = await repositories.Quests.FindAll().ToListAsync();

            var responseDTO = mapper.Map<List<QuestDTO>>(quests);

            return Ok(responseDTO);
        }

        [HttpPost("update")]
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

                return StatusCode(404, new BaseErrorResponse()
                {
                    Error = true,
                    Message = $"Cannot get quest with ID {request.ID}."
                });
            }

            return Unauthorized("Access denied");
        }
    }
}