IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [UserTypes] (
    [ID] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [AuditUser] nvarchar(max) NULL,
    [DateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_UserTypes] PRIMARY KEY ([ID])
);

GO

CREATE TABLE [Users] (
    [ID] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [UserTypeID] int NULL,
    [AuditUser] nvarchar(max) NULL,
    [DateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Users_UserTypes_UserTypeID] FOREIGN KEY ([UserTypeID]) REFERENCES [UserTypes] ([ID]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Users_UserTypeID] ON [Users] ([UserTypeID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200509185516_auditing', N'3.1.3');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserTypes]') AND [c].[name] = N'DateTime');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [UserTypes] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [UserTypes] DROP COLUMN [DateTime];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'DateTime');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Users] DROP COLUMN [DateTime];

GO

ALTER TABLE [UserTypes] ADD [LastUpdated] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Users] ADD [LastUpdated] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Users] ADD [isActive] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

CREATE TABLE [Permissions] (
    [ID] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [isActive] bit NOT NULL,
    [AuditUser] nvarchar(max) NULL,
    [LastUpdated] datetime2 NOT NULL,
    CONSTRAINT [PK_Permissions] PRIMARY KEY ([ID])
);

GO

CREATE TABLE [UserTypePermissions] (
    [UserTypeID] int NOT NULL,
    [PermissionID] int NOT NULL,
    CONSTRAINT [PK_UserTypePermissions] PRIMARY KEY ([UserTypeID], [PermissionID]),
    CONSTRAINT [FK_UserTypePermissions_Permissions_PermissionID] FOREIGN KEY ([PermissionID]) REFERENCES [Permissions] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserTypePermissions_UserTypes_UserTypeID] FOREIGN KEY ([UserTypeID]) REFERENCES [UserTypes] ([ID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_UserTypePermissions_PermissionID] ON [UserTypePermissions] ([PermissionID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200509202735_permissions', N'3.1.3');

GO

CREATE TABLE [Archetypes] (
    [ID] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [AuditUser] nvarchar(max) NULL,
    [LastUpdated] datetime2 NOT NULL,
    CONSTRAINT [PK_Archetypes] PRIMARY KEY ([ID])
);

GO

CREATE TABLE [Tags] (
    [ID] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [AuditUser] nvarchar(max) NULL,
    [LastUpdated] datetime2 NOT NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY ([ID])
);

GO

CREATE TABLE [Weights] (
    [ID] int NOT NULL IDENTITY,
    [PrimaryPercentage] int NOT NULL,
    [SecondaryPercentage] int NOT NULL,
    [TertiaryPercentage] int NOT NULL,
    [AuditUser] nvarchar(max) NULL,
    [LastUpdated] datetime2 NOT NULL,
    CONSTRAINT [PK_Weights] PRIMARY KEY ([ID])
);

GO

CREATE TABLE [UserBuilds] (
    [ID] int NOT NULL IDENTITY,
    [PrimaryArchetypeID] int NULL,
    [SecondaryArchetypeID] int NULL,
    [TertiaryArchetypeID] int NULL,
    [WeightID] int NULL,
    [AuditUser] nvarchar(max) NULL,
    [LastUpdated] datetime2 NOT NULL,
    CONSTRAINT [PK_UserBuilds] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_UserBuilds_Archetypes_PrimaryArchetypeID] FOREIGN KEY ([PrimaryArchetypeID]) REFERENCES [Archetypes] ([ID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserBuilds_Archetypes_SecondaryArchetypeID] FOREIGN KEY ([SecondaryArchetypeID]) REFERENCES [Archetypes] ([ID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserBuilds_Archetypes_TertiaryArchetypeID] FOREIGN KEY ([TertiaryArchetypeID]) REFERENCES [Archetypes] ([ID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserBuilds_Weights_WeightID] FOREIGN KEY ([WeightID]) REFERENCES [Weights] ([ID]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_UserBuilds_PrimaryArchetypeID] ON [UserBuilds] ([PrimaryArchetypeID]);

GO

CREATE INDEX [IX_UserBuilds_SecondaryArchetypeID] ON [UserBuilds] ([SecondaryArchetypeID]);

GO

CREATE INDEX [IX_UserBuilds_TertiaryArchetypeID] ON [UserBuilds] ([TertiaryArchetypeID]);

GO

CREATE INDEX [IX_UserBuilds_WeightID] ON [UserBuilds] ([WeightID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200511233257_quest-7', N'3.1.3');

GO

