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

