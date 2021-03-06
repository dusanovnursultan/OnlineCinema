
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/12/2020 15:47:10
-- Generated from EDMX file: C:\Users\dusan\Desktop\Sites\OnlineCinema\OnlineCinema\EntityModel\OnlineCinemaContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CinemaDataBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SessionsMovie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SessionsSet] DROP CONSTRAINT [FK_SessionsMovie];
GO
IF OBJECT_ID(N'[dbo].[FK_HallSessions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SessionsSet] DROP CONSTRAINT [FK_HallSessions];
GO
IF OBJECT_ID(N'[dbo].[FK_SessionsTickets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketsSet] DROP CONSTRAINT [FK_SessionsTickets];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderTickets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_OrderTickets];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[HallSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HallSet];
GO
IF OBJECT_ID(N'[dbo].[SessionsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SessionsSet];
GO
IF OBJECT_ID(N'[dbo].[MovieSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieSet];
GO
IF OBJECT_ID(N'[dbo].[TicketsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketsSet];
GO
IF OBJECT_ID(N'[dbo].[OrderSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'HallSet'
CREATE TABLE [dbo].[HallSet] (
    [IdHall] int IDENTITY(1,1) NOT NULL,
    [NameHall] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SessionsSet'
CREATE TABLE [dbo].[SessionsSet] (
    [IdSessions] int IDENTITY(1,1) NOT NULL,
    [Data] datetime  NOT NULL,
    [Time] time  NOT NULL,
    [Price] int  NOT NULL,
    [Movie_IdMovie] int  NOT NULL,
    [Hall_IdHall] int  NOT NULL
);
GO

-- Creating table 'MovieSet'
CREATE TABLE [dbo].[MovieSet] (
    [IdMovie] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Duration] time  NOT NULL,
    [SmallImg] nvarchar(max)  NOT NULL,
    [BigImg] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Assessment] int  NOT NULL,
    [StartOfRental] datetime  NOT NULL,
    [AgeRestriction] int  NOT NULL
);
GO

-- Creating table 'TicketsSet'
CREATE TABLE [dbo].[TicketsSet] (
    [IdTicket] int IDENTITY(1,1) NOT NULL,
    [Status] bit  NOT NULL,
    [Row] nvarchar(max)  NOT NULL,
    [Col] nvarchar(max)  NOT NULL,
    [IsBuy] bit  NOT NULL,
    [Sessions_IdSessions] int  NOT NULL
);
GO

-- Creating table 'OrderSet'
CREATE TABLE [dbo].[OrderSet] (
    [IdOrder] int IDENTITY(1,1) NOT NULL,
    [GuId] uniqueidentifier  NOT NULL,
    [Tickets_IdTicket] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdHall] in table 'HallSet'
ALTER TABLE [dbo].[HallSet]
ADD CONSTRAINT [PK_HallSet]
    PRIMARY KEY CLUSTERED ([IdHall] ASC);
GO

-- Creating primary key on [IdSessions] in table 'SessionsSet'
ALTER TABLE [dbo].[SessionsSet]
ADD CONSTRAINT [PK_SessionsSet]
    PRIMARY KEY CLUSTERED ([IdSessions] ASC);
GO

-- Creating primary key on [IdMovie] in table 'MovieSet'
ALTER TABLE [dbo].[MovieSet]
ADD CONSTRAINT [PK_MovieSet]
    PRIMARY KEY CLUSTERED ([IdMovie] ASC);
GO

-- Creating primary key on [IdTicket] in table 'TicketsSet'
ALTER TABLE [dbo].[TicketsSet]
ADD CONSTRAINT [PK_TicketsSet]
    PRIMARY KEY CLUSTERED ([IdTicket] ASC);
GO

-- Creating primary key on [IdOrder] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [PK_OrderSet]
    PRIMARY KEY CLUSTERED ([IdOrder] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Movie_IdMovie] in table 'SessionsSet'
ALTER TABLE [dbo].[SessionsSet]
ADD CONSTRAINT [FK_SessionsMovie]
    FOREIGN KEY ([Movie_IdMovie])
    REFERENCES [dbo].[MovieSet]
        ([IdMovie])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SessionsMovie'
CREATE INDEX [IX_FK_SessionsMovie]
ON [dbo].[SessionsSet]
    ([Movie_IdMovie]);
GO

-- Creating foreign key on [Hall_IdHall] in table 'SessionsSet'
ALTER TABLE [dbo].[SessionsSet]
ADD CONSTRAINT [FK_HallSessions]
    FOREIGN KEY ([Hall_IdHall])
    REFERENCES [dbo].[HallSet]
        ([IdHall])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HallSessions'
CREATE INDEX [IX_FK_HallSessions]
ON [dbo].[SessionsSet]
    ([Hall_IdHall]);
GO

-- Creating foreign key on [Sessions_IdSessions] in table 'TicketsSet'
ALTER TABLE [dbo].[TicketsSet]
ADD CONSTRAINT [FK_SessionsTickets]
    FOREIGN KEY ([Sessions_IdSessions])
    REFERENCES [dbo].[SessionsSet]
        ([IdSessions])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SessionsTickets'
CREATE INDEX [IX_FK_SessionsTickets]
ON [dbo].[TicketsSet]
    ([Sessions_IdSessions]);
GO

-- Creating foreign key on [Tickets_IdTicket] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_OrderTickets]
    FOREIGN KEY ([Tickets_IdTicket])
    REFERENCES [dbo].[TicketsSet]
        ([IdTicket])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderTickets'
CREATE INDEX [IX_FK_OrderTickets]
ON [dbo].[OrderSet]
    ([Tickets_IdTicket]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------