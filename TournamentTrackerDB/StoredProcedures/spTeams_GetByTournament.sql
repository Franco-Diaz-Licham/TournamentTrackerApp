CREATE PROCEDURE [TOURNAMENT_TRACKER].[spTeams_GetByTournament]
	@TournamentId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT*
	FROM 
		TOURNAMENT_TRACKER.TournamentEntries AS te
		INNER JOIN TOURNAMENT_TRACKER.Teams AS t 
			ON te.TeamId = t.Id
	WHERE 
		te.TournamentId = @TournamentId
END
GO
