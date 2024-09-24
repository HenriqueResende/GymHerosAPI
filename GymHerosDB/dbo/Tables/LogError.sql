CREATE TABLE [dbo].[LogError] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Origin]     VARCHAR (150) NOT NULL,
    [IdUser]     INT           NULL,
    [Message]    VARCHAR (MAX) NOT NULL,
    [StackTrace] VARCHAR (MAX) NULL,
    [Date]       DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__LogError__UserId__17036CC0] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE
);

