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

	DECLARE @IdUser INT
	SELECT @IdUser = SCOPE_IDENTITY()

	INSERT INTO [dbo].[Mission]
           ([IdUser], [Type], [TargetType], [Target], [Done])
     VALUES
           (@IdUser, 'Mission', 'WorkoutCount', 5, 0),
           (@IdUser, 'Mission', 'WorkoutTime', 4, 0),
           (@IdUser, 'Mission', 'VolumeWorkout', 100, 0),
           (@IdUser, 'Mission', 'VolumeTotal', 700, 0)
END