CREATE DATABASE [Tender];
GO

USE [Tender];
GO

CREATE TABLE [User] (
    [UserID] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
	[Passwd] nvarchar(max) NOT NULL
    CONSTRAINT [PK_User] PRIMARY KEY ([UserID])
);
GO

CREATE TABLE [TenderDetails] (
    [UserID] int NOT NULL,
    [ReferenceNumber] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
	[ReleaseDate] Date,
	[ClosingDate] Date,
    CONSTRAINT [PK_TenderDetails] PRIMARY KEY ([ReferenceNumber]),
	CONSTRAINT [FK_TenderDetails_User_UserID] FOREIGN KEY ([UserID]) REFERENCES [User] ([UserID]) ON DELETE CASCADE
);
GO