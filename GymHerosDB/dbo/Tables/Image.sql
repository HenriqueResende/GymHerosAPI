﻿CREATE TABLE [dbo].[Image]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[IdUser] INT NOT NULL,
    [Path] VARCHAR(50) NOT NULL, 
    [Cost] INT NOT NULL, 
    [Enable] BIT NOT NULL DEFAULT 0, 
    FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE
)
