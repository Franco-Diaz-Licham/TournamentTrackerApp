CREATE PROCEDURE [TOURNAMENT_TRACKER].[spMatchups_Insert]
	@TournamentId int,
	@MatchupRound int,
	@Id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO TOURNAMENT_TRACKER.Matchups(
		TournamentId, 
		MatchupRound)
	VALUES(
		@TournamentId, 
		@MatchupRound)

	SELECT 
		@Id = SCOPE_IDENTITY()
END
GO


