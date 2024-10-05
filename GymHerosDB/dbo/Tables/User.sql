CREATE TABLE [dbo].[User] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (250) NOT NULL,
    [Login]    VARCHAR (250) NOT NULL,
    [Password] VARCHAR (250) NOT NULL, 
    [Image] VARCHAR(50) NULL, 
    [Weight]   FLOAT (53)    NULL,
    [Height]   INT           NULL,
    [Vitality] INT           CONSTRAINT [DF__User__Vitality__5CD6CB2B] DEFAULT ((0)) NOT NULL,
    [Force] INT           CONSTRAINT [DF__User__Strength__5DCAEF64] DEFAULT ((0)) NOT NULL,
    [Defense]  INT           CONSTRAINT [DF__User__Defense__5EBF139D] DEFAULT ((0)) NOT NULL,
    [Agility]  INT           CONSTRAINT [DF__User__Agility__5FB337D6] DEFAULT ((0)) NOT NULL,
    [Level] INT NOT NULL DEFAULT 0, 
    [BossStage] INT NOT NULL DEFAULT 0, 
    [Coins] INT NOT NULL DEFAULT 0,
    CONSTRAINT [PK__User__3214EC07A88F2F56] PRIMARY KEY CLUSTERED ([Id] ASC)
);

