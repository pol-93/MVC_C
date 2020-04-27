
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/25/2020 22:07:58
-- Generated from EDMX file: C:\Users\Pol\source\repos\photoGallery\photogallery.infrastructure\Datos\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [photogallery];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[PicturesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PicturesSet];
GO
IF OBJECT_ID(N'[dbo].[ComentsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComentsSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [avatar] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [dataRegistre] datetime  NOT NULL
);
GO

-- Creating table 'PicturesSet'
CREATE TABLE [dbo].[PicturesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [picture] nvarchar(max)  NOT NULL,
    [user_id] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ComentsSet'
CREATE TABLE [dbo].[ComentsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [comentari] nvarchar(max)  NOT NULL,
    [data] nvarchar(max)  NOT NULL,
    [picture_id] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PicturesSet'
ALTER TABLE [dbo].[PicturesSet]
ADD CONSTRAINT [PK_PicturesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComentsSet'
ALTER TABLE [dbo].[ComentsSet]
ADD CONSTRAINT [PK_ComentsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------