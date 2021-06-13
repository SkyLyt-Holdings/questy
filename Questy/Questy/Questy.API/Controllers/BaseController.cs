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

        public BaseController(IRepositoryWrapper repositories, IConfiguration configuration)
        {
            this.repositories = repositories;
            this.configuration = configuration;
        }
    }
}
