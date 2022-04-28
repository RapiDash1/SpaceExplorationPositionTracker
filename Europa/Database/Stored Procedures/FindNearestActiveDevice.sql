CREATE PROCEDURE [dbo].[FindNearestActiveDevice]	
	@lat DECIMAL(8,6),
	@lon DECIMAL(9,6)
AS
BEGIN
	SET @lat = @lat * (PI()/180);
	SET @lon = @lon * (PI()/180);

	SELECT TOP(1) [Id]
      ,[Latitude]
      ,[Longitude]
      ,[DateTime]
	  ,(2 * 6371 
		* ATN2(SQRT(POWER(Sin(((Latitude * (PI()/180)) - @lat)/2), 2) + (POWER(Sin((Longitude * (PI()/180) - @lon)/2), 2)*Cos(@lat)*Cos((Latitude * (PI()/180)))))
			,SQRT(1 - (POWER(Sin(((Latitude * (PI()/180)) - @lat)/2), 2) + (POWER(Sin((Longitude * (PI()/180) - @lon)/2), 2)*Cos(@lat)*Cos((Latitude * (PI()/180)))))))) AS Distance
	  FROM [SpaceExplorationPositionTracker].[dbo].[PositionUpdate]
	  WHERE DateTime > DATEADD(day, -1, SYSDATETIMEOFFSET())
	  ORDER BY Distance;

END