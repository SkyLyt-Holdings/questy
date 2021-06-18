using Questy.Data;
using Questy.Domain.Entities;
using Questy.Infrastructure.Interfaces;

namespace Questy.Infrastructure.Repositories
{
    public class QuestRepository : BaseRepository<Quest>, IQuestRepository
    {
        public QuestRepository(QuestyContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
