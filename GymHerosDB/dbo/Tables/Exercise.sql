CREATE TABLE [dbo].[Exercise] (
    [Id]                 INT IDENTITY (1, 1) NOT NULL,
    [WorkoutId]          INT NOT NULL,
    [ExerciseTemplateId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ExerciseTemplateId]) REFERENCES [dbo].[ExerciseTemplate] ([Id]) ON DELETE CASCADE,
    FOREIGN KEY ([WorkoutId]) REFERENCES [dbo].[Workout] ([Id]) ON DELETE CASCADE
);

