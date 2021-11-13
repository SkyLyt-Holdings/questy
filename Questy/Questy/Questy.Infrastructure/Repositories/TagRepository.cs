using Questy.Data;
using Questy.Domain.Entities;
using Questy.Infrastructure.Interfaces;

namespace Questy.Infrastructure.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(QuestyContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
