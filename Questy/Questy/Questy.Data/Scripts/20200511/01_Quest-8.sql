CREATE TABLE [ArchetypeTag] (
    [ID] int NOT NULL IDENTITY,
    [ArchetypeID] int NOT NULL,
    [TagID] int NOT NULL,
    CONSTRAINT [PK_ArchetypeTag] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_ArchetypeTag_Archetypes_ArchetypeID] FOREIGN KEY ([ArchetypeID]) REFERENCES [Archetypes] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArchetypeTag_Tags_TagID] FOREIGN KEY ([TagID]) REFERENCES [Tags] ([ID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_ArchetypeTag_ArchetypeID] ON [ArchetypeTag] ([ArchetypeID]);

GO

CREATE INDEX [IX_ArchetypeTag_TagID] ON [ArchetypeTag] ([TagID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200512000752_quest-8', N'3.1.3');

GO

