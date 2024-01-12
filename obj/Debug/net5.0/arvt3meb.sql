IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Cliente] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [Email] nvarchar(120) NOT NULL,
    [Numero] int NOT NULL,
    [EnderecoId] int NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Endereço] (
    [Id] int NOT NULL IDENTITY,
    [NomeDaRua] nvarchar(max) NULL,
    [NumeroDaRua] int NOT NULL,
    [Bairro] nvarchar(max) NULL,
    [PontoDeReferencia] nvarchar(max) NULL,
    [IdCliente] int NOT NULL,
    CONSTRAINT [PK_Endereço] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Endereço_Cliente_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [Cliente] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Endereço_IdCliente] ON [Endereço] ([IdCliente]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240110181822_Teste1', N'5.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Cliente].[Numero]', N'Celular', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240111002521_teste2', N'5.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Cliente]') AND [c].[name] = N'Celular');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Cliente] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Cliente] ALTER COLUMN [Celular] nvarchar(15) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240111003141_teste3', N'5.0.0');
GO

COMMIT;
GO

