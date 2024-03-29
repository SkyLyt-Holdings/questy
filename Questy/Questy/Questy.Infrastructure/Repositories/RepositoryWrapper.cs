﻿using Questy.Data;
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
        private IQuestRepository quests;
        private ITagRepository tags;
        private IQuestTagRepository questTags;
        private IArchetypeRepository archetypes;


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
        public IQuestRepository Quests
        {
            get
            {
                if (quests == null) quests = new QuestRepository(QuestyContext);
                return quests;
            }
        }

        public ITagRepository Tags
        {
            get
            {
                if (tags == null) tags = new TagRepository(QuestyContext);
                return tags;
            }
        }

        public IQuestTagRepository QuestTags
        {
            get
            {
                if (questTags == null) questTags = new QuestTagRepository(QuestyContext);
                return questTags;
            }
        }
        
        public IArchetypeRepository Archetypes
        {
            get
            {
                if (archetypes == null) archetypes = new ArchetypeRepository(QuestyContext);
                return archetypes;
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
