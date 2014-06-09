
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/05/2014 19:24:22
-- Generated from EDMX file: D:\Usuarios\jucles\Desktop\Examen Final MF0493_3\MF0493_3\Models\ModeloDatos.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MF0493];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Empresas_Usuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empresas] DROP CONSTRAINT [FK_Empresas_Usuarios];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Empresas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empresas];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Empresas'
CREATE TABLE [dbo].[Empresas] (
    [nif] varchar(10)  NOT NULL,
    [nombre] varchar(80)  NULL,
    [email] varchar(100)  NULL,
    [ff] datetime  NULL,
    [poblacion] varchar(30)  NULL,
    [telefono] varchar(12)  NULL,
    [logo] varchar(100)  NULL,
    [activa] bit  NULL,
    [usr] varchar(20)  NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [username] varchar(20)  NOT NULL,
    [email] varchar(100)  NOT NULL,
    [passwd] varchar(100)  NOT NULL,
    [activo] bit  NOT NULL,
    [lastlogin] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [nif] in table 'Empresas'
ALTER TABLE [dbo].[Empresas]
ADD CONSTRAINT [PK_Empresas]
    PRIMARY KEY CLUSTERED ([nif] ASC);
GO

-- Creating primary key on [username] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([username] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [usr] in table 'Empresas'
ALTER TABLE [dbo].[Empresas]
ADD CONSTRAINT [FK_Empresas_Usuarios]
    FOREIGN KEY ([usr])
    REFERENCES [dbo].[Usuarios]
        ([username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Empresas_Usuarios'
CREATE INDEX [IX_FK_Empresas_Usuarios]
ON [dbo].[Empresas]
    ([usr]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------