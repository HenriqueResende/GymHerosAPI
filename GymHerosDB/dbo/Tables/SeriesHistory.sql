CREATE TABLE [dbo].[SeriesHistory] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [ExerciseHistoryId] INT NOT NULL,
    [Weight]            INT NOT NULL,
    [Rep]               INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ExerciseHistoryId]) REFERENCES [dbo].[ExerciseHistory] ([Id]) ON DELETE CASCADE
);

