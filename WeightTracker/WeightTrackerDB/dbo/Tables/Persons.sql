CREATE TABLE [dbo].[Persons] (
    [Id]     INT           NOT NULL,
    [Name]   NVARCHAR (50) NOT NULL,
    [Age]    INT           NOT NULL,
    [Height] INT           NOT NULL, 
    CONSTRAINT [PK_Persons] PRIMARY KEY ([Id])
);
