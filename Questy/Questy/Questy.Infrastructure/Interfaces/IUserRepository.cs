﻿using Questy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questy.Infrastructure.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
