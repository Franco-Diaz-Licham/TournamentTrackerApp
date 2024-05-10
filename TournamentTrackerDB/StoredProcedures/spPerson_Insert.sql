CREATE PROCEDURE [TOURNAMENT_TRACKER].[spPerson_Insert]
	-- Add the parameters for the stored procedure here
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@EmailAddress nvarchar(50),
	@CellPhoneNumber nvarchar(50),
	@Id int output

AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO TOURNAMENT_TRACKER.People(
		FirstName, 
		LastName, 
		EmailAddress,
		PhoneNumber)
	VALUES (
		@FirstName, 
		@LastName, 
		@EmailAddress, 
		@CellPhoneNumber)

	SELECT 
		@Id = SCOPE_IDENTITY()
END
GO
