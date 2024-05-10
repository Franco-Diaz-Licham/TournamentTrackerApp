CREATE PROCEDURE [TOURNAMENT_TRACKER].[spPrizes_GetByTournament]
	@TournamentId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT*
	FROM 
		TOURNAMENT_TRACKER.TournamentPrizes AS tp
		INNER JOIN TOURNAMENT_TRACKER.Prizes AS p 
			ON tp.PrizeId = p.Id
	WHERE 
		tp.TournamentId = @TournamentId
END
GO

