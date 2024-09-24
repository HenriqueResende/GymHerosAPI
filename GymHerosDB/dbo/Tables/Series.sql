CREATE TABLE [dbo].[Series] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [ExerciseId] INT NOT NULL,
    [Weight]     INT NOT NULL,
    [Rep]        INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ExerciseId]) REFERENCES [dbo].[Exercise] ([Id]) ON DELETE CASCADE
);

