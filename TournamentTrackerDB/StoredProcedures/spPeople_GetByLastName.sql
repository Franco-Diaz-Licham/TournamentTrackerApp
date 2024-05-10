CREATE PROCEDURE [TOURNAMENT_TRACKER].[spPeople_GetByLastName]
	@LastName nvarchar(50)

AS
BEGIN
	SET NOCOUNT ON;

	SELECT*
	FROM
		TOURNAMENT_TRACKER.People AS p
	WHERE 
		p.LastName = @LastName;
		
END
GO


