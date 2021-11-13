using Questy.Data;
using Questy.Domain.Entities;
using Questy.Infrastructure.Interfaces;

namespace Questy.Infrastructure.Repositories
{
     public class QuestTagRepository : BaseRepository<QuestTag>, IQuestTagRepository
    {
        public QuestTagRepository(QuestyContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
