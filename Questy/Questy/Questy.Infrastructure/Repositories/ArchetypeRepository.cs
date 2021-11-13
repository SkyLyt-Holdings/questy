using Questy.Data;
using Questy.Domain.Entities;
using Questy.Infrastructure.Interfaces;

namespace Questy.Infrastructure.Repositories
{
    public class ArchetypeRepository : BaseRepository<Archetype>, IArchetypeRepository
    {
        public ArchetypeRepository(QuestyContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
