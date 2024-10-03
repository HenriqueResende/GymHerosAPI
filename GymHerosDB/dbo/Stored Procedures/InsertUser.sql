CREATE   PROCEDURE InsertUser
@Name VARCHAR(250),
@Login VARCHAR(250),
@Password VARCHAR(250),
@Weight FLOAT,
@Height INT
AS
BEGIN
	INSERT INTO [dbo].[User]
	(
		 [Name]
		,[Login]
		,[Password]
		,[Weight]
		,[Height]
		,[Vitality]
		,[Agility]
		,[Defense]
		,[Force]
	)
     VALUES
    (
		 @Name
        ,@Login
        ,@Password
        ,@Weight
        ,@Height
		,5
		,5
		,5
		,5
	)
END