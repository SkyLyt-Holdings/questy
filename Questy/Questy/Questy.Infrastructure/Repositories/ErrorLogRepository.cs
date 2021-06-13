using Questy.Data;
using Questy.Domain.Entities.System;
using Questy.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questy.Infrastructure.Repositories
{
    public class ErrorLogRepository : BaseRepository<ErrorLog>, IErrorLogRepository
    {
        public ErrorLogRepository(QuestyContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
