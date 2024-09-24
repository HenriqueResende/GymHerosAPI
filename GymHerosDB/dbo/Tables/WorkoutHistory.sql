CREATE TABLE [dbo].[WorkoutHistory] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [IdUser]    INT      NULL,
    [WorkoutId] INT      NOT NULL,
    [Duration]  INT      NOT NULL,
    [EndDate]   DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([WorkoutId]) REFERENCES [dbo].[Workout] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK__WorkoutHi__IdUse__6FE99F9F] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE
);

