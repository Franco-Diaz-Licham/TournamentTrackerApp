CREATE PROCEDURE [TOURNAMENT_TRACKER].[spMatchupEntries]
	@MatchupId int,
	@ParentMatchupId int,
	@TeamCompetingId int,
	@Id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO TOURNAMENT_TRACKER.MatchupEntries(
		MatchupId, 
		ParentMatchupId, 
		TeamCompetingId)
	VALUES(
		@MatchupId, 
		@ParentMatchupId, 
		@TeamCompetingId)

	SELECT 
		@Id = SCOPE_IDENTITY()
END
GO

