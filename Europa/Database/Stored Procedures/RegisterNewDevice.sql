CREATE PROCEDURE [dbo].[RegisterNewDevice]
	@name VARCHAR(300),
	@description VARCHAR(MAX),
	@owner VARCHAR(100),
	@weight DECIMAL(13,5)
AS

	INSERT INTO DeviceInfo 
	(
		Name, 
		Description, 
		Owner, 
		Weight
	)
	VALUES 
	(
		@name, 
		@description, 
		@owner, 
		@weight
	);

RETURN 0
