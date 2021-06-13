using Questy.Data;
using Questy.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questy.Infrastructure.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private QuestyContext QuestyContext { get; }
        private IUserRepository users;
        private IErrorLogRepository errorLogs;

        public RepositoryWrapper(QuestyContext questyContext)
        {
            QuestyContext = questyContext;
        }

        public IUserRepository Users
        {
            get
            {
                if (users == null) users = new UserRepository(QuestyContext);
                return users;
            }
        }

        public IErrorLogRepository ErrorLogs
        {
            get
            {
                if (errorLogs == null) errorLogs = new ErrorLogRepository(QuestyContext);
                return errorLogs;
            }
        }

        public void Save()
        {
            if (QuestyContext.ChangeTracker.HasChanges())
            {
                QuestyContext.SaveChangesAsync();
            }
        }
    }
}
