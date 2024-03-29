﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Questy.Domain.Entities;
using Questy.Domain.Entities.System;

namespace Questy.Data
{
    public class QuestyContext : DbContext
    {
        public QuestyContext()
        {
        }

        public QuestyContext(DbContextOptions<QuestyContext> options)
            :base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;         
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Archetype> Archetypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserBuild> UserBuilds { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}
