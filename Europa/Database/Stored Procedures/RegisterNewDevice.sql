CREATE PROCEDURE [dbo].[RegisterNewDevice]
	@name VARCHAR(300),
	@deviceKey UNIQUEIDENTIFIER,
	@description VARCHAR(MAX),
	@owner VARCHAR(100),
	@weight DECIMAL(13,5)
AS

	INSERT INTO DeviceInfo 
	(
		Name, 
		DeviceKey,
		Description, 
		Owner, 
		Weight
	)
	VALUES 
	(
		@name, 
		@deviceKey,
		@description, 
		@owner, 
		@weight
	);

RETURN 0
