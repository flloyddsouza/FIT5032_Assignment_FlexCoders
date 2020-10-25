
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/26/2020 00:39:11
-- Generated from EDMX file: C:\Users\dsouz\source\repos\FlexCoders_Assignment\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AppDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CourseLinks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Links] DROP CONSTRAINT [FK_CourseLinks];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Courses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courses];
GO
IF OBJECT_ID(N'[dbo].[Links]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Links];
GO
IF OBJECT_ID(N'[dbo].[Workshops]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Workshops];
GO
IF OBJECT_ID(N'[dbo].[Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bookings];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CourseName] nvarchar(max)  NOT NULL,
    [CourseDescription] nvarchar(max)  NOT NULL,
    [DateUpdated] datetime  NOT NULL,
    [Contributers] nvarchar(max)  NOT NULL,
    [Language] nvarchar(max)  NOT NULL,
    [DifficultyLevel] nvarchar(max)  NOT NULL,
    [ImageURL] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Links'
CREATE TABLE [dbo].[Links] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [LinkURL] nvarchar(max)  NOT NULL,
    [CourseId] int  NOT NULL
);
GO

-- Creating table 'Workshops'
CREATE TABLE [dbo].[Workshops] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WorkshopName] nvarchar(max)  NOT NULL,
    [WorkShopDescription] nvarchar(max)  NOT NULL,
    [WorkshopDateTime] datetime  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Lat] float  NOT NULL,
    [Long] float  NOT NULL,
    [Capicity] int  NOT NULL,
    [ImageURL] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [userID] nvarchar(max)  NOT NULL,
    [workshopID] int  NOT NULL,
    [dateAndTime] datetime  NOT NULL,
    [workshopName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Links'
ALTER TABLE [dbo].[Links]
ADD CONSTRAINT [PK_Links]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Workshops'
ALTER TABLE [dbo].[Workshops]
ADD CONSTRAINT [PK_Workshops]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CourseId] in table 'Links'
ALTER TABLE [dbo].[Links]
ADD CONSTRAINT [FK_CourseLinks]
    FOREIGN KEY ([CourseId])
    REFERENCES [dbo].[Courses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseLinks'
CREATE INDEX [IX_FK_CourseLinks]
ON [dbo].[Links]
    ([CourseId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------