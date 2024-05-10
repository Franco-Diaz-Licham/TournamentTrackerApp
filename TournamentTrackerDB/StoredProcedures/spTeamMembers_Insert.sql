CREATE PROCEDURE [TOURNAMENT_TRACKER].[spTeamMembers_Insert]
	@TeamId int,
	@PersonId int

AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO TOURNAMENT_TRACKER.TeamMembers(
		TeamId,
		PersonId)
	VALUES(
		@TeamId,
		@PersonId)
			
END
GO