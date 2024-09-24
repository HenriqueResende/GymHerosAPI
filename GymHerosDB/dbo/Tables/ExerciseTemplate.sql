CREATE TABLE [dbo].[ExerciseTemplate] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [IdUser]   INT           NULL,
    [Name]     VARCHAR (100) NOT NULL,
    [Image]    VARCHAR (150) NULL,
    [Vitality] INT           NULL,
    [Strength] INT           NULL,
    [Defense]  INT           NULL,
    [Agility]  INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__ExerciseT__IdUse__6383C8BA] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE,
    UNIQUE NONCLUSTERED ([Name] ASC)
);

