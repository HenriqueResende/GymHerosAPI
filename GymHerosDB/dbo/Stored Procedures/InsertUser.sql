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
	)
     VALUES
    (
		 @Name
        ,@Login
        ,@Password
        ,@Weight
        ,@Height
	)
END