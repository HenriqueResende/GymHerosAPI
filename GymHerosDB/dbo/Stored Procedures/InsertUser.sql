/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 15/11/2024 22:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[InsertUser]
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
		,[Image]
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
		,'0'
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

	INSERT INTO [dbo].[Image]
		([IdUser], [Path], [Cost], [Enable])
	VALUES
		(@IdUser, '0', 0, 1),
		(@IdUser, '1', 10, 0),
		(@IdUser, '2', 10, 0),
		(@IdUser, '3', 10, 0),
		(@IdUser, '4', 15, 0),
		(@IdUser, '5', 15, 0),
		(@IdUser, '6', 20, 0),
		(@IdUser, '7', 20, 0)


	--Create the templates
	INSERT INTO [dbo].[ExerciseTemplate]
           ([IdUser], [Name], [Image], [Vitality], [Force], [Defense], [Agility])
     VALUES
           (@IdUser, 'Supino', 'ex_supino', 10, 0, 0, 0),
           (@IdUser, 'Flexão', 'ex_flexao', 5, 0, 0, 0),
           (@IdUser, 'Peck deck', 'ex_peckDeck', 3, 0, 0, 0),

           (@IdUser, 'Triceps', 'ex_triceps', 0, 7, 0, 0),
           (@IdUser, 'Rosca', 'ex_rosca', 0, 10, 0, 0),
           (@IdUser, 'Corda', 'ex_corda', 0, 4, 0, 0),

           (@IdUser, 'Remada', 'ex_remada', 0, 0, 5, 0),
           (@IdUser, 'Remada baixa', 'ex_remadaBaixa', 0, 0, 5, 0),
           (@IdUser, 'Puxada', 'ex_puxada', 0, 0, 7, 0),
           (@IdUser, 'Barra fixa', 'ex_barraFixa', 0, 0, 10, 0),
           (@IdUser, 'Abdominal', 'ex_abdominal', 0, 0, 3, 0),

           (@IdUser, 'Soleo', 'ex_soleo', 0, 0, 0, 3),
           (@IdUser, 'Flexora', 'ex_flexora', 0, 0, 0, 5),
           (@IdUser, 'Extensora', 'ex_extensora', 0, 0, 0, 5),
           (@IdUser, 'Agachamento sumo', 'ex_agachamentoSumo', 0, 0, 0, 8),
           (@IdUser, 'Agachamento com peso', 'ex_agachamentoPeso', 0, 0, 0, 10)


	--Peito
	INSERT INTO [dbo].[Workout]
           ([IdUser], [Name], [Image])
     VALUES
           (@IdUser, 'Peito', 'wo_peito')

	DECLARE @IdPeito INT
	SELECT @IdPeito = SCOPE_IDENTITY()

	INSERT INTO [dbo].[Exercise]
		SELECT @IdPeito, [Id] FROM ExerciseTemplate
		WHERE [IdUser] = @IdUser AND [Vitality] > 0

	--Perna
	INSERT INTO [dbo].[Workout]
           ([IdUser], [Name], [Image])
     VALUES
           (@IdUser, 'Perna', 'wo_perna')

	DECLARE @IdPerna INT
	SELECT @IdPerna = SCOPE_IDENTITY()

	INSERT INTO [dbo].[Exercise]
		SELECT @IdPerna, [Id] FROM ExerciseTemplate
		WHERE [IdUser] = @IdUser AND [Agility] > 0

	--Costa
	INSERT INTO [dbo].[Workout]
           ([IdUser], [Name], [Image])
     VALUES
           (@IdUser, 'Costa', 'wo_costa')

	DECLARE @IdCosta INT
	SELECT @IdCosta = SCOPE_IDENTITY()

	INSERT INTO [dbo].[Exercise]
		SELECT @IdCosta, [Id] FROM ExerciseTemplate
		WHERE [IdUser] = @IdUser AND [Defense] > 0

	--Braço
	INSERT INTO [dbo].[Workout]
           ([IdUser], [Name], [Image])
     VALUES
           (@IdUser, 'Braco', 'wo_braco')

	DECLARE @IdBraco INT
	SELECT @IdBraco = SCOPE_IDENTITY()

	INSERT INTO [dbo].[Exercise]
		SELECT @IdBraco, [Id] FROM ExerciseTemplate
		WHERE [IdUser] = @IdUser AND [Force] > 0


	INSERT INTO [dbo].[Series] ([ExerciseId], [Weight], [Rep])
		SELECT [Id], 10, 10 FROM [Exercise]
		WHERE [WorkoutId] IN (@IdBraco, @IdCosta, @IdPeito, @IdPerna)

	INSERT INTO [dbo].[Series] ([ExerciseId], [Weight], [Rep])
		SELECT [Id], 10, 10 FROM [Exercise]
		WHERE [WorkoutId] IN (@IdBraco, @IdCosta, @IdPeito, @IdPerna)

	INSERT INTO [dbo].[Series] ([ExerciseId], [Weight], [Rep])
		SELECT [Id], 10, 10 FROM [Exercise]
		WHERE [WorkoutId] IN (@IdBraco, @IdCosta, @IdPeito, @IdPerna)

	
	/*====================
		  TEST DATA
	====================*/

	--Create first completeed exercise
	INSERT INTO [dbo].[WorkoutHistory]
           ([IdUser], [WorkoutId], [Duration], [EndDate])
     VALUES
           (@IdUser, @IdPeito, 4800, GETDATE())

	DECLARE @IdHist1 INT
	SELECT @IdHist1 = SCOPE_IDENTITY()

	INSERT INTO [dbo].[ExerciseHistory]
		SELECT @IdHist1, [Id] FROM ExerciseTemplate
		WHERE [IdUser] = @IdUser AND [Vitality] > 0

	--Create second completeed exercise
	INSERT INTO [dbo].[WorkoutHistory]
           ([IdUser], [WorkoutId], [Duration], [EndDate])
     VALUES
           (@IdUser, @IdPeito, 4600, GETDATE())

	DECLARE @IdHist2 INT
	SELECT @IdHist2 = SCOPE_IDENTITY()

	INSERT INTO [dbo].[ExerciseHistory]
		SELECT @IdHist2, [Id] FROM ExerciseTemplate
		WHERE [IdUser] = @IdUser AND [Vitality] > 0

	--Create third completeed exercise
	INSERT INTO [dbo].[WorkoutHistory]
           ([IdUser], [WorkoutId], [Duration], [EndDate])
     VALUES
           (@IdUser, @IdPeito, 4900, GETDATE())

	DECLARE @IdHist3 INT
	SELECT @IdHist3 = SCOPE_IDENTITY()

	INSERT INTO [dbo].[ExerciseHistory]
		SELECT @IdHist3, [Id] FROM ExerciseTemplate
		WHERE [IdUser] = @IdUser AND [Vitality] > 0

	--Insert the Weight and Rep for the exercises
	INSERT INTO [dbo].[SeriesHistory] ([ExerciseHistoryId], [Weight], [Rep])
		SELECT [Id], 10, 10 FROM [ExerciseHistory]
		WHERE [WorkoutHistoryId] = @IdHist1
	INSERT INTO [dbo].[SeriesHistory] ([ExerciseHistoryId], [Weight], [Rep])
		SELECT [Id], 10, 10 FROM [ExerciseHistory]
		WHERE [WorkoutHistoryId] = @IdHist1
	INSERT INTO [dbo].[SeriesHistory] ([ExerciseHistoryId], [Weight], [Rep])
		SELECT [Id], 10, 10 FROM [ExerciseHistory]
		WHERE [WorkoutHistoryId] = @IdHist1

	INSERT INTO [dbo].[SeriesHistory] ([ExerciseHistoryId], [Weight], [Rep])
		SELECT [Id], 10, 10 FROM [ExerciseHistory]
		WHERE [WorkoutHistoryId] = @IdHist2
	INSERT INTO [dbo].[SeriesHistory] ([ExerciseHistoryId], [Weight], [Rep])
		SELECT [Id], 10, 10 FROM [ExerciseHistory]
		WHERE [WorkoutHistoryId] = @IdHist2
	INSERT INTO [dbo].[SeriesHistory] ([ExerciseHistoryId], [Weight], [Rep])
		SELECT [Id], 10, 10 FROM [ExerciseHistory]
		WHERE [WorkoutHistoryId] = @IdHist2

	INSERT INTO [dbo].[SeriesHistory] ([ExerciseHistoryId], [Weight], [Rep])
		SELECT [Id], 10, 10 FROM [ExerciseHistory]
		WHERE [WorkoutHistoryId] = @IdHist3
	INSERT INTO [dbo].[SeriesHistory] ([ExerciseHistoryId], [Weight], [Rep])
		SELECT [Id], 10, 10 FROM [ExerciseHistory]
		WHERE [WorkoutHistoryId] = @IdHist3
	INSERT INTO [dbo].[SeriesHistory] ([ExerciseHistoryId], [Weight], [Rep])
		SELECT [Id], 10, 10 FROM [ExerciseHistory]
		WHERE [WorkoutHistoryId] = @IdHist3
END