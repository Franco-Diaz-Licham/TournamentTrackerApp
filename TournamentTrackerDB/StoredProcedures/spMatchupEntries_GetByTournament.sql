CREATE PROCEDURE [TOURNAMENT_TRACKER].[spMatchupEntries_GetByTournament]
	@MatchupId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT*
	FROM 
		TOURNAMENT_TRACKER.Matchups AS mu
		INNER JOIN TOURNAMENT_TRACKER.MatchupEntries AS me 
			ON mu.Id = me.MatchupId
	WHERE 
		mu.Id = @MatchupId
END
GO

