﻿CREATE PROCEDURE [TOURNAMENT_TRACKER].[spTeam_GetAll]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT*
	FROM 
		TOURNAMENT_TRACKER.Teams
END
GO