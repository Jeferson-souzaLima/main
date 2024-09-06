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

CREATE TABLE [Categorias] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(50) NOT NULL,
    [Inclusao] datetime2 NOT NULL,
    [Alteracao] datetime2 NOT NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TB_FORNECEDOR] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Documento] varchar(14) NOT NULL,
    [TipoPessoa] int NOT NULL,
    [Ativo] bit NOT NULL,
    [Inclusao] datetime2 NOT NULL,
    [Alteracao] datetime2 NOT NULL,
    CONSTRAINT [PK_TB_FORNECEDOR] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TB_FORNECEDOR_ENDERECO] (
    [Id] uniqueidentifier NOT NULL,
    [Cep] varchar(8) NOT NULL,
    [Estado] varchar(150) NOT NULL,
    [Cidade] varchar(150) NOT NULL,
    [Bairro] varchar(100) NOT NULL,
    [Logradouro] varchar(100) NOT NULL,
    [Numero] varchar(100) NOT NULL,
    [Complemento] varchar(100) NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    [Inclusao] datetime2 NOT NULL,
    [Alteracao] datetime2 NOT NULL,
    CONSTRAINT [PK_TB_FORNECEDOR_ENDERECO] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_FORNECEDOR_ENDERECO_TB_FORNECEDOR_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [TB_FORNECEDOR] ([Id])
);
GO

CREATE TABLE [TB_PRODUTOS] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Descricao] varchar(200) NOT NULL,
    [Imagem] varchar(100) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [Ativo] bit NOT NULL,
    [CategoriaId] uniqueidentifier NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    [Inclusao] datetime2 NOT NULL,
    [Alteracao] datetime2 NOT NULL,
    CONSTRAINT [PK_TB_PRODUTOS] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_PRODUTOS_Categorias_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categorias] ([Id]),
    CONSTRAINT [FK_TB_PRODUTOS_TB_FORNECEDOR_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [TB_FORNECEDOR] ([Id])
);
GO

CREATE UNIQUE INDEX [IX_TB_FORNECEDOR_ENDERECO_FornecedorId] ON [TB_FORNECEDOR_ENDERECO] ([FornecedorId]);
GO

CREATE INDEX [IX_TB_PRODUTOS_CategoriaId] ON [TB_PRODUTOS] ([CategoriaId]);
GO

CREATE INDEX [IX_TB_PRODUTOS_FornecedorId] ON [TB_PRODUTOS] ([FornecedorId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240812201512_InicialMigration', N'8.0.6');
GO

COMMIT;
GO

