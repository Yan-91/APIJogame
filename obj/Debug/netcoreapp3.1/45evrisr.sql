IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Jogadors] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Senha] nvarchar(max) NULL,
    [DataNasc] datetime2 NOT NULL,
    CONSTRAINT [PK_Jogadors] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Jogos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Descrição] nvarchar(max) NULL,
    [DataLanç] datetime2 NOT NULL,
    CONSTRAINT [PK_Jogos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [JogoJogadores] (
    [Id] uniqueidentifier NOT NULL,
    [IdJogo] uniqueidentifier NOT NULL,
    [IdJogador] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_JogoJogadores] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_JogoJogadores_Jogadors_IdJogador] FOREIGN KEY ([IdJogador]) REFERENCES [Jogadors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_JogoJogadores_Jogos_IdJogo] FOREIGN KEY ([IdJogo]) REFERENCES [Jogos] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_JogoJogadores_IdJogador] ON [JogoJogadores] ([IdJogador]);

GO

CREATE INDEX [IX_JogoJogadores_IdJogo] ON [JogoJogadores] ([IdJogo]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200914201536_InitialCreate', N'3.1.7');

GO

