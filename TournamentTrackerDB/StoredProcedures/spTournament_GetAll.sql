﻿CREATE PROCEDURE [TOURNAMENT_TRACKER].[spTournament_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM 
		TOURNAMENT_TRACKER.Tournaments
	WHERE 
		Active = 1;
END
GO

