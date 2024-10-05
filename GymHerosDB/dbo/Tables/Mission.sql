CREATE TABLE [dbo].[Mission]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,	
    [IdUser] INT NOT NULL,
    [Type] VARCHAR(50) NOT NULL, 
    [TargetType] VARCHAR(50) NOT NULL, 
    [Target] INT NOT NULL, 
    [Reward] INT NOT NULL DEFAULT 0, 
    [Done] BIT NOT NULL DEFAULT 0, 
    FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE
)
