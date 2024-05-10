CREATE PROCEDURE [TOURNAMENT_TRACKER].[spTournament_Update]
	@Id int,
	@Complete bit
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
		TOURNAMENT_TRACKER.Tournaments
	SET 
		Active = @Complete
	WHERE 
		Id = @Id

END
GO

