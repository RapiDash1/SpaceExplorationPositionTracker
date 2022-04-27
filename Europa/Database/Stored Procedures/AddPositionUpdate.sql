CREATE PROCEDURE [dbo].[AddPositionUpdate]
	@deviceKey UNIQUEIDENTIFIER,
	@latitude DECIMAL(8,6),
	@longitude DECIMAL(9,6),
	@dateTime DATETIME
AS
	
	INSERT INTO PositionUpdate
	(
		DeviceKey,
		Latitude,
		Longitude,
		DateTime
	)
	VALUES
	(
		@deviceKey,
		@latitude,
		@longitude,
		@dateTime
	);

RETURN 0
