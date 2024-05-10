CREATE PROCEDURE [TOURNAMENT_TRACKER].[spMatchup_Update]
	@Id int,
	@WinnerId int null
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE
		TOURNAMENT_TRACKER.Matchups
	SET
		WinnerId = @WinnerId

	WHERE
		TOURNAMENT_TRACKER.Matchups.Id = @Id
END
GO

