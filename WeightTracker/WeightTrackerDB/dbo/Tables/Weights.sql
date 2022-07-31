CREATE TABLE [dbo].[Weights] (
    [PersonId]    INT        NOT NULL,
    [Id]          INT        NOT NULL,
    [Weight]      FLOAT (53) NOT NULL,
    [DateWhenAdd] DATE       NOT NULL, 
    CONSTRAINT [PK_Weights] PRIMARY KEY ([Id], [PersonId]) 
);

