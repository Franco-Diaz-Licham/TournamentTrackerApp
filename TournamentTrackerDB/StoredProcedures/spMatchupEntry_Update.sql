CREATE PROCEDURE [TOURNAMENT_TRACKER].[spMatchupEntry_Update]
	@Id int,
	@TeamCompetingId int null,
	@Score float null
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE
		TOURNAMENT_TRACKER.MatchupEntries
	SET
		TeamCompetingId = @TeamCompetingId,
		Score = @Score
	WHERE
		TOURNAMENT_TRACKER.MatchupEntries.Id = @Id
		
END
GO


