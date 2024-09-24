CREATE TABLE [dbo].[ExerciseHistory] (
    [Id]                 INT IDENTITY (1, 1) NOT NULL,
    [WorkoutHistoryId]   INT NOT NULL,
    [ExerciseTemplateId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ExerciseTemplateId]) REFERENCES [dbo].[ExerciseTemplate] ([Id]) ON DELETE CASCADE
);

