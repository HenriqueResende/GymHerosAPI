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
           ([IdUser], [Type], [TargetType], [Target], [Reward], [Done])
     VALUES
           (@IdUser, 'Mission', 'WorkoutCount', 5, 10, 0),
           (@IdUser, 'Mission', 'WorkoutTime', 4, 10, 0),
           (@IdUser, 'Mission', 'VolumeWorkout', 100, 10, 0),
           (@IdUser, 'Mission', 'VolumeTotal', 700, 10, 0),

           (@IdUser, 'Achievement', 'WorkoutCount', 1, 10, 0),
           (@IdUser, 'Achievement', 'WorkoutCount', 10, 10, 0),
           (@IdUser, 'Achievement', 'WorkoutCount', 50, 30, 0),
           (@IdUser, 'Achievement', 'WorkoutCount', 75, 50, 0),
           (@IdUser, 'Achievement', 'WorkoutCount', 100, 100, 0),

           (@IdUser, 'Achievement', 'WorkoutTime', 1, 10, 0),
           (@IdUser, 'Achievement', 'WorkoutTime', 50, 10, 0),
           (@IdUser, 'Achievement', 'WorkoutTime', 100, 25, 0),
           (@IdUser, 'Achievement', 'WorkoutTime', 150, 30, 0),
           (@IdUser, 'Achievement', 'WorkoutTime', 200, 50, 0),

           (@IdUser, 'Achievement', 'VolumeWorkout', 100, 5, 0),
           (@IdUser, 'Achievement', 'VolumeWorkout', 500, 10, 0),
           (@IdUser, 'Achievement', 'VolumeWorkout', 1000, 30, 0),
           (@IdUser, 'Achievement', 'VolumeWorkout', 1500, 50, 0),
           (@IdUser, 'Achievement', 'VolumeWorkout', 2000, 100, 0),

           (@IdUser, 'Achievement', 'VolumeTotal', 1000, 5, 0),
           (@IdUser, 'Achievement', 'VolumeTotal', 10000, 10, 0),
           (@IdUser, 'Achievement', 'VolumeTotal', 20000, 30, 0),
           (@IdUser, 'Achievement', 'VolumeTotal', 30000, 50, 0),
           (@IdUser, 'Achievement', 'VolumeTotal', 100000, 100, 0),

           (@IdUser, 'Achievement', 'Level', 3, 5, 0),
           (@IdUser, 'Achievement', 'Level', 10, 10, 0),
           (@IdUser, 'Achievement', 'Level', 50, 30, 0),
           (@IdUser, 'Achievement', 'Level', 70, 50, 0)
END