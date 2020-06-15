IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Clientes] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Produtos] (
    [Id] uniqueidentifier NOT NULL,
    [clienteId] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Produtos_Clientes_clienteId] FOREIGN KEY ([clienteId]) REFERENCES [Clientes] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Produtos_clienteId] ON [Produtos] ([clienteId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200610164045_First', N'5.0.0-preview.4.20220.10');

GO

