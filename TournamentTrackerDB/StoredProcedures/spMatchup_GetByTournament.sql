CREATE PROCEDURE [TOURNAMENT_TRACKER].[spMatchup_GetByTournament]
	@TournamentId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT*
	FROM 
		TOURNAMENT_TRACKER.Matchups AS mu
	WHERE
		mu.TournamentId = @TournamentId
END
GO