CREATE PROCEDURE [TOURNAMENT_TRACKER].[spPrizes_Insert]
	@PlaceNumber int,
	@PlaceName nvarchar(50),
	@PrizeAmount money,
	@PrizePercentage float,
	@Id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO TOURNAMENT_TRACKER.Prizes(
		PlaceNumber, 
		PlaceName, 
		PrizeAmount,
		PrizePercentage)
	VALUES (
		@PlaceNumber, 
		@PlaceName, 
		@PrizeAmount, 
		@PrizePercentage)
	SELECT 
		@Id = SCOPE_IDENTITY();
		
END
GO