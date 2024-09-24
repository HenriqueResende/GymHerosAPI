CREATE TABLE [dbo].[Workout] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [IdUser] INT           NULL,
    [Name]   VARCHAR (100) NOT NULL,
    [Image]  VARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

