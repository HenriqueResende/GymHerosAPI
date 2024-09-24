CREATE PROCEDURE InserLogError    
@Origin VARCHAR(150),    
@Message VARCHAR(MAX),    
@IdUser INT = NULL,    
@StackTrace VARCHAR(MAX) = NULL,    
@Date DATETIME = NULL    
AS    
BEGIN    
    
INSERT INTO [dbo].[LogError]    
           ([Origin]    
           ,[IdUser]    
           ,[Message]    
           ,[StackTrace]    
           ,[Date])    
     VALUES    
           (@Origin    
           ,@IdUser    
           ,@Message    
           ,@StackTrace    
           ,@Date)    
END