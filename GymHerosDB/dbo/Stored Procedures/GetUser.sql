  
CREATE   PROCEDURE GetUser
@Id INT = NULL,  
@Login VARCHAR(250) = NULL
AS  
BEGIN  
 SELECT TOP 1  
       [Id]  
      ,[Name]  
      ,[Login]  
      ,[Password]
      ,[Image]
      ,[Weight]  
      ,[Height]  
      ,[Vitality]  
      ,[Force]
      ,[Defense]  
      ,[Agility]
      ,[Coins]
      ,[Level]
      ,[BossStage]
 FROM [User]  
 WHERE (@Login IS NULL AND @Id = Id) 
OR (@Id IS NULL AND @Login = [Login])
END