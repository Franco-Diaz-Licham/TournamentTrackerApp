CREATE PROCEDURE [TOURNAMENT_TRACKER].[spTournament_Insert]
	@TournamentName varchar(100),
	@EntryFee money,
	@Id int = 0 output

AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO TOURNAMENT_TRACKER.Tournaments(
		TournamentName,
		EntryFee,
		Active)
	VALUES(
		@TournamentName,
		@EntryFee,
		1)

	SELECT
		@Id = SCOPE_IDENTITY()
END
GO

