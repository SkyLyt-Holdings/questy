using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Questy.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questy.API.Controllers
{
    public class BaseController : ControllerBase
    {
        public readonly IRepositoryWrapper repositories;
        public IConfiguration configuration;
        public bool IsAdmin = false;

        public BaseController(IServiceProvider serviceProvider, IRepositoryWrapper repositories, IConfiguration configuration)
        {
            this.repositories = repositories;
            this.configuration = configuration;

            IHttpContextAccessor httpContextAccessor = serviceProvider.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;

            if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {

                IsAdmin = Convert.ToBoolean(httpContextAccessor.HttpContext.User.FindFirst("IsAdmin").Value);
            }
        }
    }
}
