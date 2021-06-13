using Questy.Data;
using Questy.Domain.Entities;
using Questy.Infrastructure.Interfaces;

namespace Questy.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(QuestyContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
