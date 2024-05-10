CREATE PROCEDURE [TOURNAMENT_TRACKER].[spTournamentPrizes_Insert]
	@TournamentId int,
	@PrizeId int,
	@Id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO TOURNAMENT_TRACKER.TournamentPrizes(
		TournamentId,
		PrizeId)
	VALUES(
		@TournamentId,
		@PrizeId)
	
	SELECT
		@Id = SCOPE_IDENTITY()
END
GO

