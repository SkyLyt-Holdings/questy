using Questy.Data;
using Questy.Domain.Entities;

namespace Questy.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(QuestyContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
