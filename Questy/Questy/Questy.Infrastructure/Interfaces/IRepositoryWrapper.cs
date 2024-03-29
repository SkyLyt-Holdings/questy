﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questy.Infrastructure.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository Users { get; }
        IErrorLogRepository ErrorLogs { get; }
        IQuestRepository Quests { get; }
        ITagRepository Tags { get; }
        IQuestTagRepository QuestTags { get; }
        IArchetypeRepository Archetypes { get; }
        void Save();
    }
}
